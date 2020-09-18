using Microsoft.AspNetCore.Mvc;
using TripNotes.Models;

namespace TripNotes.Controllers
{
  public class HomeController : Controller
  {
    private readonly TripNotesContext _db;
    public HomeController(TripNotesContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }
    
  }
}