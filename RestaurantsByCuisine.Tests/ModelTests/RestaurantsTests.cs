using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using RestarantsByCuisineModels;
using System;

namespace RestarantsByCuisine.Tests
{

  [TestClass]
  public class RestaurantTests : IDisposable
  {

    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Restaurant.ClearAll();
    }
    
    public RestaurantTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    // [TestMethod]
    // public void RestaurantConstructor_CreatesInstanceOfRestaurant_Restaurant()
    // {
    //   Restaurant newRestaurant = new Restaurant("test");
    //   Assert.AreEqual(typeof(Restaurant), newRestaurant.GetType());
    // }

    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";

    //   //Act
    //   Restaurant newRestaurant = new Restaurant(description);
    //   string result = newRestaurant.Description;

    //   //Assert
    //   Assert.AreEqual(description, result);
    // }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Restaurant newRestaurant = new Restaurant(description);

    //   //Act
    //   string updatedDescription = "Do the dishes";
    //   newRestaurant.Description = updatedDescription;
    //   string result = newRestaurant.Description;

    //   //Assert
    //   Assert.AreEqual(updatedDescription, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_RestaurantList()
    {
      // Arrange
      List<Restaurant> newList = new List<Restaurant> { };

      // Act
      List<Restaurant> result = Restaurant.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRestaurants_RestaurantList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Restaurant newRestaurant1 = new Restaurant(description01);
      newRestaurant1.Save();
      Restaurant newRestaurant2 = new Restaurant(description02);
      newRestaurant2.Save();
      List<Restaurant> newList = new List<Restaurant> { newRestaurant1, newRestaurant2 };

      //Act
      List<Restaurant> result = Restaurant.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Restaurant()
    {
      // Arrange, Act
      Restaurant firstRestaurant = new Restaurant("Mow the lawn");
      Restaurant secondRestaurant = new Restaurant("Mow the lawn");

      // Assert
      Assert.AreEqual(firstRestaurant, secondRestaurant);
    }

    [TestMethod]
    public void Save_SavesToDatabase_RestaurantList()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Mow the lawn");

      //Act
      testRestaurant.Save();
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRestaurantFromDatabase_Restaurant()
    {
      //Arrange
      Restaurant newRestaurant = new Restaurant("Mow the lawn");
      newRestaurant.Save();
      Restaurant newRestaurant2 = new Restaurant("Wash dishes");
      newRestaurant2.Save();

      //Act
      Restaurant foundRestaurant = Restaurant.Find(newRestaurant.Id);
      //Assert
      Assert.AreEqual(newRestaurant, foundRestaurant);
    }
  }
}
