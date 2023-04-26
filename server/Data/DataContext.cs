using Microsoft.EntityFrameworkCore;
using server.Core.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(DbContextOptions options): base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
}