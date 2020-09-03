namespace TripNotes.Models
{
  public class HorseRace
  {
    public int HorseRaceId { get; set; }
    public int HorseId { get; set; }
    public int RaceId { get; set; }
    public string HorseNotes { get; set; }
    public Horse Horse { get; set; }
    public Race Race { get; set; }
  }
}