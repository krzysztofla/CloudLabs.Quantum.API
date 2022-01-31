using CloudLabs.Quantum.API.Entities;
using MediatR;

namespace CloudLabs.Quantum.API.Queries;

public class GetCoinQuery : IRequest<Coin>
{
    public Guid Id { get; set; }

    public GetCoinQuery(Guid id)
    {
        Id = id;
    }
}