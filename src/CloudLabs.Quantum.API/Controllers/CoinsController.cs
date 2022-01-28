using CloudLabs.Quantum.API.Dto;
using CloudLabs.Quantum.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace CloudLabs.Quantum.API.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class CoinsController : ControllerBase
{
    private readonly ILogger<CoinsController> _logger;

    private readonly ICoinService _coinService;

    public CoinsController(ILogger<CoinsController> logger, ICoinService coinService)
    {
        _logger = logger;
        _coinService = coinService;
    }
    
    [HttpPost()]
    public async Task<ActionResult> Post([FromBody]CoinDto coin, CancellationToken token)
    {
        await _coinService.Add(coin);
        return Ok();
    }
    
}