#pragma warning disable CS8618

namespace Products_N_Categories.Models
{
    public class ProductsPageViewModel
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; } = [];

    }
}
