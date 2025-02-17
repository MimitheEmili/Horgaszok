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
    public class HorgaszokController : ControllerBase
    {
        // Get a list of all horgász
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (var cx = new HorgaszokContext())
                {
                    return Ok(cx.Horgaszok.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get a specific horgász by ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                using (var cx = new HorgaszokContext())
                {
                    var horgasz = cx.Horgaszok.FirstOrDefault(h => h.Horgaszok_Id == id);
                    if (horgasz == null)
                        return NotFound("Horgász nem található.");
                    return Ok(horgasz);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add a new horgász
        [HttpPost]
        public IActionResult Post(Horgaszok horgasz)
        {
            try
            {
                using (var cx = new HorgaszokContext())
                {
                    cx.Horgaszok.Add(horgasz);
                    cx.SaveChanges();
                    return StatusCode(StatusCodes.Status202Accepted, "Horgász hozzáadva.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(432, ex.Message);
            }
        }

        // Update an existing horgász
        [HttpPut]
        public IActionResult Put(Horgaszok horgasz)
        {
            try
            {
                using (var cx = new HorgaszokContext())
                {
                    cx.Horgaszok.Update(horgasz);
                    cx.SaveChanges();
                    return Ok("Horgász módosítva.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a horgász by ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (var cx = new HorgaszokContext())
                {
                    Horgaszok horgasz = new Horgaszok { Horgaszok_Id = id };
                    cx.Horgaszok.Remove(horgasz);
                    cx.SaveChanges();
                    return Ok("Horgász törölve.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
