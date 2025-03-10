
using Horgaszadatok.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Horgaszadatok.Controllers
{
    [Route("[controller]")]
        [ApiController]
    public class FogasokController : Controller
    {

        private readonly HalakContext _context;

        // Konstruktor, ahol a HorgaszokContext injektálva van
        public FogasokController(HalakContext context)
        {
            _context = context;
        }

        // Get a list of all catches
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var fogasok = _context.Fogasoks.Include(f => f.Hal).Include(f => f.Horgaszok).ToList();
                return Ok(fogasok);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a specific catch by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var fogas = _context.Fogasoks.Include(f => f.Hal).Include(f => f.Horgaszok).FirstOrDefault(f => f.fogasok_id == id);
                if (fogas == null)
                    return NotFound("Fogás nem található.");
                return Ok(fogas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add a new catch
        [HttpPost]
        public IActionResult Post(Fogasok fogas)
        {
            try
            {
                _context.Fogasoks.Add(fogas);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, "Fogás hozzáadva.");
            }
            catch (Exception ex)
            {
                return StatusCode(432, ex.Message);
            }
        }

        // Update an existing catch
        [HttpPut]
        public IActionResult Put(Fogasok fogas)
        {
            try
            {
                _context.Fogasoks.Update(fogas);
                _context.SaveChanges();
                return Ok("Fogás módosítva.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a catch by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var fogas = new Fogasok { fogasok_id = id };
                _context.Fogasoks.Remove(fogas);
                _context.SaveChanges();
                return Ok("Fogás törölve.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
