using Microsoft.EntityFrameworkCore;

namespace RestarauntsByCuisine.Models
{
  public class RestarauntsByCuisineContext : DbContext
  {
    public DbSet<Cuisine> Cuisine { get; set; }
    public DbSet<Restaraunt> Restaraunt { get; set; }

    public RestarauntsByCuisineContext(DbContextOptions options) : base(options) { }
  }
}