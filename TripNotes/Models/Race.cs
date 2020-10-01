using System.Collections.Generic;
using System;

namespace TripNotes.Models
{
  public class Race
  {
    public Race()
    {
      this.Horses = new HashSet<HorseRace>();
      // this.Paces = new HashSet<Pace>();
    }
    public int RaceId { get; set; }
    public string RaceDate { get; set; }
    public string RaceLength  { get; set; }
    public string RaceClass { get; set; }
    public string RaceNotes { get; set; }
    public ICollection<HorseRace> Horses { get; set; }
    // public virtual ICollection<Pace> Paces { get; set; } //one race to many paces? paces viewed through lens of race?
  }
}