using System.Collections.Generic;
using System;

namespace TripNotes.Models
{
  public class Race
  {
    public Race()
    {
      this.Horses = new HashSet<HorseRace>();
    }
    public int RaceId { get; set; }
    public string RaceDate { get; set; }
    public string RaceLength  { get; set; }
    public string RaceClass { get; set; }
    public string RaceNotes { get; set; }
    public virtual ICollection<HorseRace> Horses { get; set; }
  }
}