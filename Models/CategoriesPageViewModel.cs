#pragma warning disable CS8618


namespace Products_N_Categories.Models;

public class CategoriesPageViewModel
{
    public Category Category { get; set; }
    public List<Category> Categories { get; set; } = [];
}
