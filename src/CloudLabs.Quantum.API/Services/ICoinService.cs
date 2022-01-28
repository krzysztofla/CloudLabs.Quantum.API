using CloudLabs.Quantum.API.Dto;
using CloudLabs.Quantum.API.Entities;

namespace CloudLabs.Quantum.API.Services;

public interface ICoinService
{
    Task Add(CoinDto coin);
}