namespace IceCream.Shared.Dtos;

public record struct IcecreamOptionDto (string Flavor, string Topping);
public record IcecreamDto(int Id, string Name, string Image, double Price, IcecreamOptionDto[] Options);
