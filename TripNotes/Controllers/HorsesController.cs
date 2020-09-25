using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripNotes.Models;
using System;
using System.Linq;

namespace TripNotes.Controllers
{
  public class HorsesController : Controller
  {
    private readonly TripNotesContext _db;
    public HorsesController(TripNotesContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
        public async Task<IActionResult> Create(string searchString) //removed async for functionality, suggested in this doc https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-3.1
    {
      // ViewBag.HorseId = new SelectList(_db.Horses, "HorseId", "HorseName");

      // ViewBag.Horses = _db.Horses;
      var horses = from horse in _db.Horses select horse;
      if (!string.IsNullOrEmpty(searchString))
      {
        horses = horses.Where(horse => horse.HorseName.Contains(searchString));
      }
      return View(await horses.ToListAsync()); 
    }
    public ActionResult Create(Horse horse)
    {
      _db.Horses.Add(horse);
      _db.SaveChanges();
      return View();
    }

    public ActionResult Details(int id)
    {
      var thisHorse = _db.Horses
      .Include(horse => horse.Races)
      .ThenInclude(join => join.Race)
      .FirstOrDefault(horse => horse.HorseId == id);
      return View(thisHorse);
    }

    [HttpPost]

    public ActionResult Edit(Horse horse, int RaceId)
    {
      if (RaceId !=0)
      {
        _db.HorseRace.Add(new HorseRace() { RaceId = RaceId, HorseId = horse.HorseId});
      }
      _db.Entry(horse).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisHorse = _db.Horses.FirstOrDefault(horse => horse.HorseId == id);
      return View(thisHorse);
    } 

    [HttpPost]

    public ActionResult DeleteConfirmed(int id)
    {
      var thisHorse = _db.Horses.FirstOrDefault(horse => horse.HorseId == id);
      _db.Horses.Remove(thisHorse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]

    public ActionResult DeleteRace(int joinId)
    {
      var joinEntry = _db.HorseRace.FirstOrDefault(entry => entry.HorseRaceId == joinId);
      _db.HorseRace.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}