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
      ViewBag.PageName = "Machine List";
      if (id <= 0)
      {
        List<Machine> model = _db.Machines.ToList();
        return View(model);
      }
      else
      {
        ViewBag.ThisMachine = _db.Machines
          .Include(machine => machine.JoinEntities)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(machine => machine.MachineId == id);
        ViewBag.ListOfEngineers = _db.Engineers.ToList();
        List<Machine> model = _db.Machines.ToList();
        return View(model);
      }
    }
    public ActionResult Create()
    {
      ViewBag.ListOfEngineers = _db.Engineers.ToList();
      ViewBag.PageName = "Add Machine";
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult AddEngineer(int MachineId, int EngineerId)
    {
      // Machine thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == MachineId);
      _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = EngineerId });
      _db.SaveChanges();
      return RedirectToAction("Index", "Machines", new { id = MachineId });
    }

  }
}
