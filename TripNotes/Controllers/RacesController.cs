using Microsoft.AspNetCore.Mvc;
using TripNotes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



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
        races = races.Where(race => race.RaceDate.Contains(searchString));
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
      var horsesQuery = from d in _db.Horses
                          orderby d.HorseName
                          select d;
      ViewBag.HorseId = new SelectList(horsesQuery, "HorseId", "HorseName");
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
      var horsesQuery = from d in _db.Horses
                          orderby d.HorseName
                          select d;
      ViewBag.HorseId = new SelectList(horsesQuery.AsNoTracking(), "HorseId", "HorseName");
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

    public ActionResult AddNotes(int id)
    {
      var thisRace = _db.Races
      .Include(race => race.Horses)
      .ThenInclude(join => join.Horse)
      .FirstOrDefault(race => race.RaceId == id);
      return View(thisRace);
    }

    [HttpPost]
    public ActionResult AddNotes(string horseRace)
      {
        List<string> HorseRaceList = new List<string>{};
        if(String.IsNullOrEmpty(horseRace))
        {
          System.Console.WriteLine("null oh no!");
        } else {
          HorseRaceList = horseRace.Split(",").ToList();
        }

            for (int i = 0; i < HorseRaceList.Count; i++) {
              int id = int.Parse(HorseRaceList[0]);
              string horseNotes = HorseRaceList[1].ToString();
              int horsePerformance = int.Parse(HorseRaceList[2]);
              var thisHorseRace = _db.HorseRace.Single(m => m.HorseRaceId == id);
              thisHorseRace.HorseNotes = horseNotes;
              thisHorseRace.HorsePerformance = horsePerformance;
              HorseRaceList.RemoveRange(0, 3);
              _db.SaveChanges();
        }
      return RedirectToAction("Index");
      }

      [HttpPost]
      public ActionResult AddRaceNotes(Race race)
        {
          var thisRace = _db.Races.FirstOrDefault(r => r.RaceId == race.RaceId);
          thisRace.RaceNotes = race.RaceNotes;;
          _db.SaveChanges();

          return RedirectToAction("Index");

        }

        public ActionResult AddPace(int id)
        {
          var thisRace = _db.Races
          .Include(race => race.Horses)
          .ThenInclude(join => join.Horse)
          .FirstOrDefault(race => race.RaceId == id);
          return View(thisRace);
        }

        [HttpPost]
        public ActionResult AddPace(string horsePace)
        {
          List<string> HorsePaceList = new List<string>{};
          if(String.IsNullOrEmpty(horsePace))
          {
            System.Console.WriteLine("null oh no!");
          } else {
            HorsePaceList = horsePace.Split(",").ToList();
          }
          Console.WriteLine(horsePace);

              for (int i = 0; i < HorsePaceList.Count; i++) {
                int id = int.Parse(HorsePaceList[0]);
                double first = Math.Round(float.Parse(HorsePaceList[1]), 2);
                double second = Math.Round(float.Parse(HorsePaceList[2]), 2);
                double third = Math.Round(float.Parse(HorsePaceList[3]), 2);
                double early = Math.Round(float.Parse(HorsePaceList[4]), 2);
                var thisHorseRace = _db.HorseRace.Single(m => m.HorseRaceId == id);
                thisHorseRace.FirstFR = first;
                thisHorseRace.SecondFR = second;
                thisHorseRace.ThirdFR = third;
                thisHorseRace.EP = early;
                HorsePaceList.RemoveRange(0, 5);
                _db.SaveChanges();
          }
        return RedirectToAction("Index");
        }

  }
}

