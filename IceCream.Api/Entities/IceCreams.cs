using System.ComponentModel.DataAnnotations;

namespace IceCream.Api.Entities;

public class IceCreams
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string? Name { get; set; }
    [Range(0.1, double.MaxValue)]
    public double Price { get; set; }
    [Required, MaxLength(130)]
    public string? Image { get; set; }
    public virtual ICollection<IceCreamOption>? Options { get; set; }
}
