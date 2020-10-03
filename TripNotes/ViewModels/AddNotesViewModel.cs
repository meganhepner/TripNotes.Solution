using TripNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TripNotes.ViewModels
{
  public class AddNotesViewModel
  {
    // public AddNotesViewModel()
    // {
    //   this.Horses = new HashSet<HorseRace>();
    // }
    public Race race { get; set; }
    public Horse horse { get; set; }
    public HorseRace horseRace { get; set; }
    public ICollection<Horse> Horses { get; set; }
    public ICollection<Race> Races { get; set; }
    public ICollection<HorseRace> HorseRaces { get; set; }

  }
}