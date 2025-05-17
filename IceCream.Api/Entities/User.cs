using System.ComponentModel.DataAnnotations;

namespace IceCream.Api.Entities;

public class User
{
    public Guid Id { get; set; }
    [Required, MaxLength(60)]
    public string? Name { get; set; }
    [Required, MaxLength(100)]
    public string? Email { get; set; }
    [Required, MaxLength(150)]
    public string? Address { get; set; }
    [Required, MaxLength(20)]
    public string? Salt { get; set; }
    [Required, MaxLength(180)]
    public string? Hash { get; set; }
}