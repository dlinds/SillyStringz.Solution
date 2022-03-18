using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index(int id = 0)
    {
      if (id <= 0) {
        ViewBag.PageName = "Machine List";
        List<Machine> model = _db.Machines.ToList();
        return View(model);
      } else {
        ViewBag.PageName = "Machine List";
        ViewBag.ThisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        List<Machine> model = _db.Machines.ToList();
        return View(model);
      }
    }
    public ActionResult Create()
    {
      ViewBag.PageName = "Add Machine";
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return View("Index");
    }
  }
}
