#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace Products_N_Categories.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    public List<Category> Categories { get; set; } = [];
    public string Name { get; set; }
    // navigational property

    public List<Association> AssociatedCategories { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
