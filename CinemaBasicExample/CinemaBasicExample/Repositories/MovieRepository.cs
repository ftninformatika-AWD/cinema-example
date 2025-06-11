using CinemaBasicExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBasicExample.Repositories
{
    public class MovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _context.Movies
                .Include(s => s.Genre)
                .ToListAsync();
        }

        public async Task<Movie?> GetOne(int id)
        {
            return await _context.Movies
                .Include(s => s.Genre)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Update(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Add(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
