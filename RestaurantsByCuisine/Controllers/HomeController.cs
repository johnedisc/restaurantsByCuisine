using Microsoft.AspNetCore.Mvc;

namespace RestaurantsByCuisine.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}