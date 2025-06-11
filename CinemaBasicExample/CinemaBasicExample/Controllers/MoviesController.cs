using CinemaBasicExample.Models;
using CinemaBasicExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBasicExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieRepository _moviesRepository;

        public MoviesController(AppDbContext context)
        {
            _moviesRepository = new MovieRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            return Ok(await _moviesRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _moviesRepository.GetOne(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            await _moviesRepository.Update(movie);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _moviesRepository.Add(movie);
            return Created(string.Empty, movie);
            // Returns 201 without Location header (first param), and includes object (second param)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _moviesRepository.GetOne(id);
            if (movie == null)
            {
                return NotFound();
            }

            await _moviesRepository.Delete(movie);
            return NoContent();
        }
    }
}
