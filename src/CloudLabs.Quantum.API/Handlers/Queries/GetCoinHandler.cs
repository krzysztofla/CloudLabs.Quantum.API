using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.Queries;
using CloudLabs.Quantum.API.Services;
using MediatR;

namespace CloudLabs.Quantum.API.Handlers.Queries;

public class GetCoinHandler : IRequestHandler<GetCoinQuery, Coin>
{
    private readonly ICoinService _service;

    public GetCoinHandler(ICoinService service)
    {
        _service = service;
    }

    public async Task<Coin> Handle(GetCoinQuery request, CancellationToken cancellationToken)
    {
        var coin = await _service.GetCoin(request.Id);
        return coin;
    }
}