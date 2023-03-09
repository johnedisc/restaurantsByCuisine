using MySqlConnector;

namespace RestaurantsByCuisine.Models
{
  public class Restaurant
  {
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }
    public string Description { get; set; }
    public int RestaurantId { get; set; }

  }
}
