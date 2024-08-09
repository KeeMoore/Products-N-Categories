
using Microsoft.EntityFrameworkCore;

using Products_N_Categories.Models;

namespace Products_N_Categories.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Association> Associations { get; set; }
}
