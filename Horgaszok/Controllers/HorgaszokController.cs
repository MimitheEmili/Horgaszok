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
    public class HorgaszokController : ControllerBase
    {
        private readonly HalakContext _context;

        public HorgaszokController(HalakContext context)
        {
            _context = context;
        }

        // Get all horgászok
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Horgaszoks.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get horgász by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var horgasz = _context.Horgaszoks.FirstOrDefault(h => h.horgaszok_id == id);
                if (horgasz == null)
                    return NotFound("Horgász nem található.");
                return Ok(horgasz);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add new horgász
        [HttpPost]
        public IActionResult Post(Horgaszok horgasz)  // <-- Helyes típus
        {
            try
            {
                _context.Horgaszoks.Add(horgasz);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Horgász hozzáadva.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Update existing horgász
        [HttpPut]
        public IActionResult Put(Horgaszok horgasz)  // <-- Helyes típus
        {
            try
            {
                _context.Horgaszoks.Update(horgasz);
                _context.SaveChanges();
                return Ok("Horgász módosítva.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete horgász by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var horgasz = _context.Horgaszoks.Find(id);
                if (horgasz == null)
                    return NotFound("Horgász nem található.");

                _context.Horgaszoks.Remove(horgasz);
                _context.SaveChanges();
                return Ok("Horgász törölve.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
