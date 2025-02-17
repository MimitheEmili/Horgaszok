using Horgaszok.Class;
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
    public class FogasokController : Controller
    {
        
            private readonly HorgaszokContext _context;

            // Konstruktor, ahol a HorgaszokContext injektálva van
            public FogasokController(HorgaszokContext context)
            {
                _context = context;
            }

            // Get a list of all catches
            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    var fogasok = _context.Fogasok.Include(f => f.Hal).Include(f => f.Horgaszok).ToList();
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
                    var fogas = _context.Fogasok.Include(f => f.Hal).Include(f => f.Horgaszok).FirstOrDefault(f => f.Fogasok_Id == id);
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
                    _context.Fogasok.Add(fogas);
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
                    _context.Fogasok.Update(fogas);
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
                    var fogas = new Fogasok { Fogasok_Id = id };
                    _context.Fogasok.Remove(fogas);
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
