using TripNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TripNotes.ViewModels
{
  public class AddNotesViewModel
  {
    public IEnumerable<Race> Races { get; set; }
    public Horse horse { get; set; }
    public HorseRace horseRace { get; set; }
  }
}