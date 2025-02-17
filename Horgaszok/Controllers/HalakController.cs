using Horgaszok.Class;
using Horgaszok.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Horgaszok.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HalakController : ControllerBase
    {
        private readonly HorgaszokContext _context;

        // A HorgaszokContext DI által történő injektálása
        public HalakController(HorgaszokContext context)
        {
            _context = context;
        }

        // Get a list of all fish
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Halak.ToList());
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
                var hal = _context.Halak.FirstOrDefault(h => h.Halak_Id == id);
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
                _context.Halak.Add(hal);
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
                _context.Halak.Update(hal);
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
                Halak hal = new Halak { Halak_Id = id };
                _context.Halak.Remove(hal);
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
