using CloudLabs.Quantum.API.Configuration.CosmosDb;
using CloudLabs.Quantum.API.Configuration.CosmosDb.DataInitializer;
using CloudLabs.Quantum.API.Repositories;
using CloudLabs.Quantum.API.Services;
using CloudLabs.Quantum.API.Settings;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.InstallCosmosDb(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<IFakeDataInitializer, FakeDataInitializer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
 
    var settings = new CosmosDbSettings();

    builder.Configuration.GetSection("CosmosDb").Bind(settings);

    if (settings.InitializeData)
    {
     var dataInitializer = app.Services.GetService<IFakeDataInitializer>();
     dataInitializer.InitializeData();
    }
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();