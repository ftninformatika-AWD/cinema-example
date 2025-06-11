using CinemaBasicExample.Models;
using CinemaBasicExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBasicExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreRepository _genresRepository;

        public GenresController(AppDbContext context)
        {
            _genresRepository = new GenreRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            return Ok(await _genresRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await _genresRepository.GetOne(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Genre>> PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            await _genresRepository.Update(genre);
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            await _genresRepository.Add(genre);
            return Created(string.Empty, genre);
            // Returns 201 without Location header (first param), and includes object (second param)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genresRepository.GetOne(id);
            if (genre == null)
            {
                return NotFound();
            }

            await _genresRepository.Delete(genre);
            return NoContent();
        }
    }
}
