using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestaurantsByCuisine.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsByCuisine.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly RestaurantsByCuisineContext _db;
    public CuisinesController(RestaurantsByCuisineContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine category)
    {
      _db.Cuisines.Add(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines
                                  .Include(cuisine => cuisine.Restaurants)
                                  .FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine category)
    {
      _db.Cuisines.Update(category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(category => category.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
