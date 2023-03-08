using System.Collections.Generic;
using MySqlConnector;

namespace RestaurantsByCuisine.Models
{
  public class Restaurant
  {
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }
    public string Description { get; set; }
    public int RestaurantId { get; set; }

    public Restaurant(string description)
    {
      Description = description;
    }
    public Restaurant(string description, int id)
    {
      Description = description;
      Id = id;
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if (!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = (this.Id == newRestaurant.Id);
        bool descriptionEquality = (this.Description == newRestaurant.Description);
        return (idEquality && descriptionEquality);
      }
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO restaurants (description) VALUES (@RestaurantDescription);";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@RestaurantDescription";
      param.Value = this.Description;

      cmd.Parameters.Add(param);    

      cmd.ExecuteNonQuery();

      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Restaurant Find(int id)
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM `restaurants` WHERE id = @ThisId;";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;

      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int restaurantId = 0;
      string restaurantDescription = "";
      while (rdr.Read())
      {
        restaurantId = rdr.GetInt32(0);
        restaurantDescription = rdr.GetString(1);
      }
      Restaurant foundRestaurant = new Restaurant(restaurantDescription, restaurantId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRestaurant;
    }

    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant> { };

      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM restaurants;";

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int restaurantId = rdr.GetInt32(0);
          string restaurantDescription = rdr.GetString(1);
          Restaurant newRestaurant = new Restaurant(restaurantDescription, restaurantId);
          allRestaurants.Add(newRestaurant);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allRestaurants;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM restaurants;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
