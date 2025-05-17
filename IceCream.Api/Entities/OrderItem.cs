using System.ComponentModel.DataAnnotations;

namespace IceCream.Api.Entities;

public class OrderItem
{
    [Key]
    public long Id { get; set; }
    public long OrderId { get; set; }
    public int IceCreamId { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    [Required, MaxLength(50)]
    public string? Flavor { get; set; }
    [Required, MaxLength(50)]
    public string? Topping { get; set; }
    public double TotalPrice { get; set; }
    public virtual Order? Order { get; set; }
}