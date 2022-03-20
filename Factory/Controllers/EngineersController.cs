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

    [HttpPost]
    public ActionResult RemoveMachineFromEnginner(int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      string message = "SUCCESS";
      return Json(new { Message = message });
    }

    [HttpPost]
    public ActionResult AddEngineerToMachine(int machineId, int engineerId)
    {
      // Machine thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == MachineId);
      _db.EngineerMachine.Add(new EngineerMachine() { MachineId = machineId, EngineerId = engineerId });
      _db.SaveChanges();
      var joinEntry = _db.EngineerMachine.FirstOrDefault(e => e.EngineerId == engineerId && e.MachineId == machineId);
      // var joinEntry = _db.Engineers
      //     .Include(e => e.JoinEntities)
      //     .ThenInclude(join => join.Engineer)
      //     .FirstOrDefault(e => e.EngineerId == engineerId);
      // var test = _db.Engineers.FirstOrDefault(e => e.JoinEntities).ThenInclude(join => join.Machine).ToList();
      return Json(new { joinId = joinEntry.EngineerMachineId, machineId = joinEntry.MachineId });
    }
  }
}
