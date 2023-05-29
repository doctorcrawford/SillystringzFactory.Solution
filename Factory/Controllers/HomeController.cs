using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers;

public class HomeController : Controller
{
  private readonly FactoryContext _db;

  public HomeController(FactoryContext db)
  {
    _db = db;
  }

  [HttpGet("/")]
  public ActionResult Index()
  {
    var splashPageInfo = new SplashPageInfo {
      Engineers = _db.Engineers,
      Machines = _db.Machines
    };
    return View(splashPageInfo);
  }
}

public class SplashPageInfo
{
  public IEnumerable<Engineer> Engineers {get; set;}
  public IEnumerable<Machine> Machines {get; set;}
}