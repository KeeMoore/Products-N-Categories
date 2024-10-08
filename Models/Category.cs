#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_N_Categories.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();

    // navigational property
    public List<Association> AssociatedProducts { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}