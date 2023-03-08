using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using RestaurantsByCuisine.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantsByCuisine.Controllers
{
  public class CuisinesController : Controller
  {

    [HttpGet("/cuisines")]
    public ActionResult Index()
    {
      List<Cuisine> allCuisines = Cuisine.GetAll();
      return View(allCuisines);
    }

    [HttpGet("/cuisines/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/cuisines")]
    public ActionResult Create(string cuisineName)
    {
      Cuisine newCuisine = new Cuisine(cuisineName);
      return RedirectToAction("Index");
    }

    [HttpGet("/cuisines/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Cuisine selectedCuisine = Cuisine.Find(id);
      List<Restaurant> categoryRestaurants = selectedCuisine.Restaurants;
      model.Add("cuisine", selectedCuisine);
      model.Add("restaurants", cuisineRestaurants);
      return View(model);
    }


    // This one creates new Items within a given Category, not new Cuisines:

    [HttpPost("/cuisines/{cuisineId}/restaurants")]
    public ActionResult Create(int cuisineId, string restaurantDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Cuisine foundCuisine = Cuisine.Find(cuisineId);
      Restaurant newRestaurant = new Restaurant(restaurantDescription);
      newRestaraunt.Save();    // New code
      foundCuisine.AddRestaurant(newRestaurant);
      List<Restaurant> cuisineRestaurants = foundCuisine.Restaurants;
      model.Add("restaurants", cuisineRestaurants);
      model.Add("cuisine", foundCuisine);
      return View("Show", model);
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines
                                  .Include(cuisine => cuisine.Restaurants)
                                  .FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }
  }
}