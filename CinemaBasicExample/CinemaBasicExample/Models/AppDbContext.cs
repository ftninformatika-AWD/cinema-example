using Microsoft.EntityFrameworkCore;

namespace CinemaBasicExample.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Screening> Screenings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Drama" },
                new Genre { Id = 4, Name = "Horror" },
                new Genre { Id = 5, Name = "Sci-Fi" }
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Eclipse of Shadows", Duration = 120, GenreId=3 },
                new Movie { Id = 2, Name = "The Last Horizon", Duration = 110, GenreId = 2 },
                new Movie { Id = 3, Name = "Whispers of the Wind", Duration = 130, GenreId = 5 },
                new Movie { Id = 4, Name = "Crimson Tide Rising", Duration = 140, GenreId = 4 },
                new Movie { Id = 5, Name = "Echoes of Eternity", Duration = 100, GenreId = 1 },
                new Movie { Id = 6, Name = "Into the Depths", Duration = 150, GenreId = 2 },
                new Movie { Id = 7, Name = "Starlight Chronicles", Duration = 125, GenreId = 3 },
                new Movie { Id = 8, Name = "The Forgotten Realm", Duration = 95, GenreId = 4 },
                new Movie { Id = 9, Name = "Beyond the Veil", Duration = 105, GenreId = 3 },
                new Movie { Id = 10, Name = "Shattered Reflections", Duration = 11, GenreId = 1 }
            );

            // Seed Screenings
            modelBuilder.Entity<Screening>().HasData(
                new Screening { Id = 1, ScheduledAt = new DateTime(2026, 1, 5, 10, 0, 0, DateTimeKind.Utc), Room = 1, ScreeningType = "2D", TicketPrice = 10.0, MovieId = 1 },
                new Screening { Id = 2, ScheduledAt = new DateTime(2026, 1, 6, 12, 30, 0, DateTimeKind.Utc), Room = 2, ScreeningType = "3D", TicketPrice = 12.5, MovieId = 2 },
                new Screening { Id = 3, ScheduledAt = new DateTime(2026, 1, 7, 15, 0, 0, DateTimeKind.Utc), Room = 3, ScreeningType = "IMAX", TicketPrice = 15.0, MovieId = 3 },
                new Screening { Id = 4, ScheduledAt = new DateTime(2026, 1, 8, 18, 0, 0, DateTimeKind.Utc), Room = 4, ScreeningType = "4D", TicketPrice = 20.0, MovieId = 4 },
                new Screening { Id = 5, ScheduledAt = new DateTime(2026, 1, 9, 20, 0, 0, DateTimeKind.Utc), Room = 5, ScreeningType = "2D", TicketPrice = 10.0, MovieId = 5 },
                new Screening { Id = 6, ScheduledAt = new DateTime(2026, 2, 1, 11, 0, 0, DateTimeKind.Utc), Room = 6, ScreeningType = "3D", TicketPrice = 12.5, MovieId = 6 },
                new Screening { Id = 7, ScheduledAt = new DateTime(2026, 2, 2, 13, 30, 0, DateTimeKind.Utc), Room = 7, ScreeningType = "IMAX", TicketPrice = 15.0, MovieId = 7 },
                new Screening { Id = 8, ScheduledAt = new DateTime(2026, 2, 3, 16, 0, 0, DateTimeKind.Utc), Room = 8, ScreeningType = "4D", TicketPrice = 20.0, MovieId = 8 },
                new Screening { Id = 9, ScheduledAt = new DateTime(2026, 2, 4, 19, 0, 0, DateTimeKind.Utc), Room = 1, ScreeningType = "2D", TicketPrice = 10.0, MovieId = 9 },
                new Screening { Id = 10, ScheduledAt = new DateTime(2026, 2, 5, 21, 0, 0, DateTimeKind.Utc), Room = 2, ScreeningType = "3D", TicketPrice = 12.5, MovieId = 10 },
                new Screening { Id = 11, ScheduledAt = new DateTime(2026, 3, 1, 10, 0, 0, DateTimeKind.Utc), Room = 3, ScreeningType = "IMAX", TicketPrice = 15.0, MovieId = 1 },
                new Screening { Id = 12, ScheduledAt = new DateTime(2026, 3, 2, 12, 30, 0, DateTimeKind.Utc), Room = 4, ScreeningType = "4D", TicketPrice = 20.0, MovieId = 2 },
                new Screening { Id = 13, ScheduledAt = new DateTime(2026, 3, 3, 15, 0, 0, DateTimeKind.Utc), Room = 5, ScreeningType = "2D", TicketPrice = 10.0, MovieId = 3 },
                new Screening { Id = 14, ScheduledAt = new DateTime(2026, 3, 4, 18, 0, 0, DateTimeKind.Utc), Room = 6, ScreeningType = "3D", TicketPrice = 12.5, MovieId = 4 },
                new Screening { Id = 15, ScheduledAt = new DateTime(2026, 3, 5, 20, 0, 0, DateTimeKind.Utc), Room = 7, ScreeningType = "IMAX", TicketPrice = 15.0, MovieId = 5 },
                new Screening { Id = 16, ScheduledAt = new DateTime(2026, 4, 1, 10, 0, 0, DateTimeKind.Utc), Room = 8, ScreeningType = "4D", TicketPrice = 20.0, MovieId = 6 },
                new Screening { Id = 17, ScheduledAt = new DateTime(2026, 4, 2, 13, 30, 0, DateTimeKind.Utc), Room = 1, ScreeningType = "2D", TicketPrice = 10.0, MovieId = 7 },
                new Screening { Id = 18, ScheduledAt = new DateTime(2026, 4, 3, 16, 0, 0, DateTimeKind.Utc), Room = 2, ScreeningType = "3D", TicketPrice = 12.5, MovieId = 8 },
                new Screening { Id = 19, ScheduledAt = new DateTime(2026, 4, 4, 19, 0, 0, DateTimeKind.Utc), Room = 3, ScreeningType = "IMAX", TicketPrice = 15.0, MovieId = 9 },
                new Screening { Id = 20, ScheduledAt = new DateTime(2026, 4, 5, 21, 0, 0, DateTimeKind.Utc), Room = 4, ScreeningType = "4D", TicketPrice = 20.0, MovieId = 10 }
            );
        }
    }
}
