using System.Collections.Generic;
using System;

namespace TripNotes.Models
{
  public class Horse
  {
    public Horse()
    {
      this.Races = new HashSet<HorseRace>();
    }
    public int HorseId { get; set; }
    public string HorseName { get; set; }
    // public virtual ICollection<HorseRace> HorseRaces { get; set; }
    public ICollection<HorseRace> Races { get; set; }

  }
}