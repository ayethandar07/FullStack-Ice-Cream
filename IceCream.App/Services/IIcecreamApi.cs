using IceCream.Shared.Dtos;
using Refit;

namespace IceCream.App.Services;

public interface IIcecreamApi
{
    [Get("/api/icecreams")]
    Task<IcecreamDto[]> GetIcecreamsAsync();
}