using System.ComponentModel.DataAnnotations;

namespace Products_N_Categories.Models;

public class Association
{
    [Key]
    public int AssociationId { get; set; }

    // this tracks the associated Category's id
    public int CategoryId { get; set; }
    // navigational property
    public Category? Category { get; set; }

    // this tracks the associated Product's id
    public int ProductId { get; set; }
    // navigational property
    public Product? Product { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"ProductId: {ProductId}, CategoryId{CategoryId}";
    }
}