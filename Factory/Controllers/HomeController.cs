using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.PageName = "Home";
      return View();
    }
  }
}
