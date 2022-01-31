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
    
    public async Task AddCoin(CoinDto coinDto)
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

    public async Task<Coin> GetCoin(Guid guid)
    {
        var coin = await _coinRepository.GetCoin(guid);
        return coin;
    }

    public async Task UpdateCoin(CoinDto coinDto)
    {
        var coin = await _coinRepository.GetCoin(coinDto.Id);
        coin.Name = coinDto.Name;
        coin.Description = coinDto.Description;
        coin.CoinType = Enum.Parse<CoinType>(coinDto.CoinType);
        coin.UpdatedAt = DateTime.UtcNow;

        await _coinRepository.UpdateCoin(coin);
    }

    public async Task RemoveCoin(CoinDto coinDto)
    {
        var coin = await _coinRepository.GetCoin(coinDto.Id);
        await _coinRepository.RemoveCoin(coin);
    }

    public async Task AddPrice(Guid id, Price price)
    {
        var coin = await _coinRepository.GetCoin(id);
        coin.PriceHistory.Add(price);
        await _coinRepository.UpdateCoin(coin);
    }
}