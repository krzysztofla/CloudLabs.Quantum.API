using System.Text.Json;
using CloudLabs.Quantum.API.Dto;
using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.Queries;
using CloudLabs.Quantum.API.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CloudLabs.Quantum.API.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class CoinsController : ControllerBase
{
    private readonly ILogger<CoinsController> _logger;

    private readonly ICoinService _coinService;

    private readonly IInMemoryCacheService _cache;

    private readonly IMediator _mediator;

    public CoinsController(ILogger<CoinsController> logger, ICoinService coinService, IMediator mediator, IInMemoryCacheService cache)
    {
        _logger = logger;
        _coinService = coinService;
        _mediator = mediator;
        _cache = cache;
    }

    [HttpPost()]
    public async Task<ActionResult> Post([FromBody] CoinDto coin, CancellationToken token)
    {
        await _coinService.AddCoin(coin);
        return Ok();
    }

    [HttpGet()]
    public async Task<IActionResult> Get([FromQuery]Guid id)
    {
        var query = new GetCoinQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("cache")]
    public async Task<IActionResult> SetCacheData([FromBody] Coin coin)
    {
        await _cache.SetCacheDataAsync(coin.id.ToString(), JsonConvert.SerializeObject(coin));
        return Ok();
    }
    
    [HttpGet("cache/{key}")]
    public async Task<IActionResult> GetCacheData([FromRoute] string key)
    {
        var coin = await _cache.GetCachedDataAsync(key);
        return Ok(JsonConvert.DeserializeObject(coin));
    }
}