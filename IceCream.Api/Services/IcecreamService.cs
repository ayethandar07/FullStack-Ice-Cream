using IceCream.Api.Data;
using IceCream.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace IceCream.Api.Services;

public class IcecreamService(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<IcecreamDto[]> GetIcecreamsAsync() => 
        await _context.IceCreams
        .AsNoTracking()
        .Select(i => new IcecreamDto 
            (   i.Id,
                i.Name,
                i.Image,
                i.Price,
                i.Options.Select(o => new IcecreamOptionDto
                (   o.Flavor,
                    o.Topping))
                    .ToArray()))
            .ToArrayAsync();
}
