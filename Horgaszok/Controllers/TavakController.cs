
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
    public class TavakController : ControllerBase
    {
        private readonly HalakContext _context;

        public TavakController(HalakContext context)
        {
            _context = context;
        }

        // Összes tó lekérdezése
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Tavaks.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Egy adott tó lekérdezése ID alapján
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var to = _context.Tavaks.FirstOrDefault(t => t.tavak_id == id);
                if (to == null)
                    return NotFound("A megadott tó nem található.");
                return Ok(to);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Új tó hozzáadása
        [HttpPost]
        public IActionResult Post(Tavak to)
        {
            try
            {
                _context.Tavaks.Add(to);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Tó hozzáadva.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Tó módosítása
        [HttpPut]
        public IActionResult Put(Tavak to)
        {
            try
            {
                _context.Tavaks.Update(to);
                _context.SaveChanges();
                return Ok("Tó módosítva.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Tó törlése ID alapján
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var to = _context.Tavaks.Find(id);
                if (to == null)
                    return NotFound("A megadott tó nem található.");

                _context.Tavaks.Remove(to);
                _context.SaveChanges();
                return Ok("Tó törölve.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}