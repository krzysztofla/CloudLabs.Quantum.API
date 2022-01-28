using CloudLabs.Quantum.API.Dto;
using CloudLabs.Quantum.API.Entities;
using CloudLabs.Quantum.API.Repositories;
using CloudLabs.Quantum.API.ValueObjects;

namespace CloudLabs.Quantum.API.Services;

public class CoinService : ICoinService
{
    private readonly ICoinRepository _coinRepository;
    
    public CoinService(ICoinRepository coinRepository)
    {
        _coinRepository = coinRepository;
    }
    
    public async Task Add(CoinDto coinDto)
    {
        var coin = new Coin()
        {
            id = coinDto.Id,
            Name = coinDto.Name,
            Description = coinDto.Description,
            CoinType =  Enum.Parse<CoinType>(coinDto.CoinType, true)
        };
       await _coinRepository.AddCoin(coin);
    }
}