using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Factory.Controllers;

public class MachinesController : Controller
{
  private readonly FactoryContext _db;

  public MachinesController(FactoryContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    var splashPageInfo = new SplashPageInfo{
      Machines = _db.Machines
    };
    
    return View(splashPageInfo);
  }

  public static List<DropdownValue> StatusDropdownValues = Enum
      .GetValues<Machine.StatusType>()
      .Select(h =>
      {
        var asString = h.ToString();
        return new DropdownValue { Value = asString, DisplayName = asString };
      })
      .ToList();


  public class DropdownValue
  {
    public string Value { get; set; }
    public string DisplayName { get; set; }
  }

  public ActionResult Create()
  {
    SetDataForCreatePage();

    return View();
  }

  private void SetDataForCreatePage()
  {
    ViewBag.StatusDropdownOptions = StatusDropdownValues;
  }

  [HttpPost]
  public ActionResult Create(Machine machine)
  {
    if (!ModelState.IsValid)
    {
      SetDataForCreatePage();
      return View(machine);
    }
    else
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
  }

  public ActionResult Details(int id)
  {
    Machine thisMachine = _db.Machines
          .Include(e => e.EngineerMachines)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(machine => machine.MachineId == id);
    return View(thisMachine);
  }

  public ActionResult Edit(int id)
  {
    Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    SetDataForCreatePage();

    return View(thisMachine);
  }

  [HttpPost]
  public ActionResult Edit(Machine machine)
  {
    _db.Machines.Update(machine);
    _db.SaveChanges();

    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    
    return View(thisMachine);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    _db.Machines.Remove(thisMachine);
    _db.SaveChanges();

    return RedirectToAction("Index");
  }

  public ActionResult AddEngineer(int id)
  {
    Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
    ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
    ViewBag.Engineers = _db.Engineers.ToList();

    return View(thisMachine);
  }

  [HttpPost]
  public ActionResult AddEngineer(Machine machine, int engineerId)
  {
#nullable enable
    EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
#nullable disable
    if (joinEntity == null && engineerId != 0)
    {
      _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = engineerId, MachineId = machine.MachineId });
      _db.SaveChanges();
    }

    return RedirectToAction("Details", new { id = machine.MachineId });
  }

  [HttpPost]
  public ActionResult DeleteJoin(int joinId)
  {
    EngineerMachine engMachine = _db.EngineerMachines
          .Include(e => e.Machine)
          .FirstOrDefault(entry => entry.EngineerMachineId == joinId);
    _db.EngineerMachines.Remove(engMachine);
    _db.SaveChanges();

    return RedirectToAction("Details", new { id = engMachine.Machine.MachineId });
  }
}