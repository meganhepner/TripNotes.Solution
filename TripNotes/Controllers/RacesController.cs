using Microsoft.AspNetCore.Mvc;
using TripNotes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TripNotes.ViewModels;

namespace TripNotes.Controllers
{
  public class RacesController : Controller
  {
    private readonly TripNotesContext _db;
    public RacesController(TripNotesContext db)
    {
      _db = db;
    }
    public ActionResult Index(string sortOrder, string searchString)
    {
      ViewBag.DateSortParm = sortOrder=="Date" ? "date_desc" : "Date";
      var races = from race in _db.Races select race;
      if(!string.IsNullOrEmpty(searchString))
      {
        // races = races.Where(race => race.RaceDate.Contains(searchString));
      }
      switch (sortOrder)
      {
        case "Date":
          races = races.OrderBy(race => race.RaceDate);
          break;
        case "date_desc":
          races = races.OrderByDescending(race => race.RaceDate);
          break;
      }
      return View(races.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.HorseId = new SelectList(_db.Horses, "HorseId", "HorseName");
      return View();
    }

    [HttpPost]
    public JsonResult SaveData(string race, string horses)
    {
      string [] HorseIdArray = horses.Split(",");
      var serializedata = JsonConvert.DeserializeObject<Race>(race);
      _db.Races.Add(serializedata);
      foreach (var element in HorseIdArray)
      {
        var ThisHorseId = int.Parse(element);
        _db.HorseRace.Add(new HorseRace() { HorseId = ThisHorseId, RaceId = serializedata.RaceId});
      }
      _db.SaveChanges();
    
      return Json("success");
    }
    public ActionResult Details(int id)
    {
      var thisRace = _db.Races
      .Include(race => race.Horses)
      .ThenInclude(join => join.Horse)
      .FirstOrDefault(race => race.RaceId == id);
      return View(thisRace);
    }
    public ActionResult Edit(int id)
    {
      var thisRace = _db.Races.FirstOrDefault(races => races.RaceId == id);
      ViewBag.HorseId = new SelectList(_db.Horses, "HorseId", "HorseName");
      return View(thisRace);
    }

    [HttpPost]
    
    public ActionResult Edit(Race race, int HorseId)
    {
      if (HorseId != 0)
      {
        _db.HorseRace.Add(new HorseRace() { HorseId = HorseId, RaceId = race.RaceId});
      }
      _db.Entry(race).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRace = _db.Races.FirstOrDefault(race => race.RaceId == id);
      return View(thisRace);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRace = _db.Races.FirstOrDefault(race => race.RaceId == id);
      _db.Races.Remove(thisRace);
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

    public ActionResult AddHorse(int id)
    {
      var thisRace = _db.Races.FirstOrDefault(race => race.RaceId == id);
      ViewBag.HorseId = new SelectList(_db.Horses, "HorseId", "HorseName");
      return View(thisRace);
    }

    [HttpPost]
    public ActionResult AddHorse(Horse horse, int RaceId)
    {
      if(RaceId != 0)
      {
        _db.HorseRace.Add(new HorseRace() { RaceId = RaceId, HorseId = horse.HorseId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddNote(int id)
    {
      var thisRace = _db.Races.FirstOrDefault(race => race.RaceId == id);
      HorseRaceViewModel horseRaceViewModel = new HorseRaceViewModel();
      {
        
      }
      return View(thisRace);
    }

  }
}