using CloudLabs.Quantum.API.Dto;
using CloudLabs.Quantum.API.Queries;
using CloudLabs.Quantum.API.Services;
using MediatR;
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

    private readonly IMediator _mediator;

    public CoinsController(ILogger<CoinsController> logger, ICoinService coinService, IMediator mediator)
    {
        _logger = logger;
        _coinService = coinService;
        _mediator = mediator;
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
}