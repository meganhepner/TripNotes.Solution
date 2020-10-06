namespace TripNotes.Models
{
  public class HorseRace
  {
    public int HorseRaceId { get; set; }
    public int HorseId { get; set; }
    public int RaceId { get; set; }
    public string HorseNotes { get; set; }
    public int HorsePerformance { get; set; }
    public double FirstFR { get; set; }
    public double SecondFR { get; set; }
    public double ThirdFR { get; set; }
    public double AP { get; set; }
    public double EP { get; set; }
    public double SP { get; set; }
    public double FX { get; set; }
    public double PercentEarly { get; set; }
    public Horse Horse { get; set; }
    public Race Race { get; set; }
  }
}