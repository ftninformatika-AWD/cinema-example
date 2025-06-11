using CinemaBasicExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaBasicExample.Repositories
{
    public class ScreeningRepository
    {
        private readonly AppDbContext _context;

        public ScreeningRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Screening>> GetAll()
        {
            return await _context.Screenings
                .Include(s => s.Movie).ThenInclude(m => m.Genre)
                .ToListAsync();
        }

        public async Task<Screening?> GetOne(int id)
        {
            return await _context.Screenings
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task Update(Screening screening)
        {
            _context.Screenings.Update(screening);
            await _context.SaveChangesAsync();
        }

        public async Task Add(Screening screening)
        {
            _context.Screenings.Add(screening);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Screening screening)
        {
            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();
        }
    }
}
