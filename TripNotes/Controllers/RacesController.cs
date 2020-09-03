using Microsoft.AspNetCore.Mvc;
using TripNotes.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TripNotes.Controllers
{
  public class RacesController : Controller
  {
    private readonly TripNotesContext _db;
    public RacesController(TripNotesContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View();
    }
  }
}