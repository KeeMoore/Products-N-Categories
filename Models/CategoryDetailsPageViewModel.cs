#pragma warning disable CS8618

namespace Products_N_Categories.Models;

public class CategoryDetailsPageViewModel
{
    public Category Category { get; set; }
    public Association Association { get; set; }
    public List<Product> Products { get; set; } = [];
}

