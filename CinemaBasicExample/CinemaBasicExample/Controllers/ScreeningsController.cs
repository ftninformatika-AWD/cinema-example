using CinemaBasicExample.Models;
using CinemaBasicExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBasicExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreeningsController : ControllerBase
    {
        private readonly ScreeningRepository _screeningsRepository;

        public ScreeningsController(AppDbContext context)
        {
            _screeningsRepository = new ScreeningRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Screening>>> GetScreenings()
        {
            return Ok(await _screeningsRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Screening>> GetScreening(int id)
        {
            var screening = await _screeningsRepository.GetOne(id);

            if (screening == null)
            {
                return NotFound();
            }

            return Ok(screening);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Screening>> PutScreening(int id, Screening screening)
        {
            if (id != screening.Id)
            {
                return BadRequest();
            }

            await _screeningsRepository.Update(screening);
            return Ok(screening);
        }

        [HttpPost]
        public async Task<ActionResult<Screening>> PostScreening(Screening screening)
        {
            await _screeningsRepository.Add(screening);
            return Created(string.Empty, screening);
            // Returns 201 without Location header (first param), and includes object (second param)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreening(int id)
        {
            var screening = await _screeningsRepository.GetOne(id);
            if (screening == null)
            {
                return NotFound();
            }

            await _screeningsRepository.Delete(screening);
            return NoContent();
        }
    }
}
