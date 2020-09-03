using System.Collections.Generic;
using System;

namespace TripNotes.Models
{
  public class Pace
  {
    // public Pace()
    // {
    //   this.Horses = new HashSet<HorsePace>();
    // }
    public int PaceId { get; set; }
    public DateTime RaceDate { get; set; }
    public string RaceLength  { get; set; }

     public int RaceId { get; set; }
    public virtual Race Race { get; set; }
    // public ICollection<HorsePace> Horses { get; set; }


  }
}