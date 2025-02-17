using Horgaszok.Class;  // Horgaszok osztály betöltése
using Horgaszok.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Horgaszok.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HorgaszokController : ControllerBase
    {
        private readonly HorgaszokContext _context;

        public HorgaszokController(HorgaszokContext context)
        {
            _context = context;
        }

        // Get all horgászok
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Horgaszok.ToList());
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
                var horgasz = _context.Horgaszok.FirstOrDefault(h => h.Horgaszok_Id == id);
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
        public IActionResult Post(Horgaszok.Class.Horgaszok horgasz)
        {
            try
            {
                _context.Horgaszok.Add(horgasz);
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
        public IActionResult Put(Horgaszok.Class.Horgaszok horgasz)
        {
            try
            {
                _context.Horgaszok.Update(horgasz);
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
                var horgasz = _context.Horgaszok.Find(id);
                if (horgasz == null)
                    return NotFound("Horgász nem található.");

                _context.Horgaszok.Remove(horgasz);
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
