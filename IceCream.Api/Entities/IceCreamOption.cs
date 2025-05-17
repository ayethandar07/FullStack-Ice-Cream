using System.ComponentModel.DataAnnotations;

namespace IceCream.Api.Entities;

public class IceCreamOption
{
    public int IceCreamId { get; set; }
    [Required, MaxLength(50)]
    public string? Flavor { get; set; }
    [Required, MaxLength(50)]
    public string? Topping { get; set; }
    public virtual IceCreams? IceCream { get; set; }
}
