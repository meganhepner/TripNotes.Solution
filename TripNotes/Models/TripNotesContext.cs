using Microsoft.EntityFrameworkCore;

namespace TripNotes.Models
{
  public class TripNotesContext : DbContext
  {
    public virtual DbSet<Horse> Horses { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Pace> Paces { get; set; }

    public TripNotesContext(DbContextOptions options) : base(options) { }
  }
}