
using Horgaszadatok.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Horgaszadatok.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HalakController : ControllerBase
    {
        private readonly HalakContext _context;

        // A HorgaszokContext DI által történő injektálása
        public HalakController(HalakContext context)
        {
            _context = context;
        }

        // Get a list of all fish
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Halaks.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a specific fish by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var hal = _context.Halaks.FirstOrDefault(h => h.halak_id == id);
                if (hal == null)
                    return NotFound("Hal nem található.");
                return Ok(hal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add a new fish
        [HttpPost]
        public IActionResult Post(Halak hal)
        {
            try
            {
                _context.Halaks.Add(hal);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, "Hal hozzáadva.");
            }
            catch (Exception ex)
            {
                return StatusCode(432, ex.Message);
            }
        }

        // Update an existing fish
        [HttpPut]
        public IActionResult Put(Halak hal)
        {
            try
            {
                _context.Halaks.Update(hal);
                _context.SaveChanges();
                return Ok("Hal módosítva.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a fish by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Halak hal = new Halak { halak_id = id };
                _context.Halaks.Remove(hal);
                _context.SaveChanges();
                return Ok("Hal törölve.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
