using Microsoft.EntityFrameworkCore;

namespace RestaurantsByCuisine.Models
{
  public class RestaurantsByCuisineContext : DbContext
  {
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    public RestaurantsByCuisineContext(DbContextOptions options) : base(options) { }
  }
}
