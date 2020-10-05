namespace TripNotes.Models
{
  public class HorseRace
  {
    public int HorseRaceId { get; set; }
    public int HorseId { get; set; }
    public int RaceId { get; set; }
    public string HorseNotes { get; set; }
    public int HorsePerformance { get; set; }
    public int FirstFR { get; set; }
    public int SecondFR { get; set; }
    public int ThirdFR { get; set; }
    public int AP { get; set; }
    public int EP { get; set; }
    public int SP { get; set; }
    public int FX { get; set; }
    public int PercentEarly { get; set; }
    public Horse Horse { get; set; }
    public Race Race { get; set; }
  }
}