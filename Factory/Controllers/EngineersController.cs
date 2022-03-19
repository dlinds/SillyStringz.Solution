using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      ViewBag.PageName = "Engineer List";
      ViewBag.ListOfMachines = _db.Machines.ToList();
      List<Engineer> model = _db.Engineers.Include(e => e.JoinEntities).ThenInclude(join => join.Machine).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.PageName = "Add Engineer";
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
