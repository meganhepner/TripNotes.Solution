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
    public ActionResult Index(string sortOrder, string searchString)
    {
      return View();
    }

  }
}