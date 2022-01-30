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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();