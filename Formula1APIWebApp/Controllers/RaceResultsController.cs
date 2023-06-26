using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Formula1APIWebApp.Models;

namespace Formula1APIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceResultsController : ControllerBase
    {
        private readonly Formula1APIContext _context;

        public RaceResultsController(Formula1APIContext context)
        {
            _context = context;
        }

        // GET: api/RaceResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResult>>> GetRaceResults()
        {
          if (_context.RaceResults == null)
          {
              return NotFound();
          }
            return await _context.RaceResults.ToListAsync();
        }

        // GET: api/RaceResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceResult>> GetRaceResult(int id)
        {
          if (_context.RaceResults == null)
          {
              return NotFound();
          }
            var raceResult = await _context.RaceResults.FindAsync(id);

            if (raceResult == null)
            {
                return NotFound();
            }

            return raceResult;
        }

        // PUT: api/RaceResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceResult(int id, RaceResult raceResult)
        {
            if (id != raceResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(raceResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceResultExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RaceResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RaceResult>> PostRaceResult(RaceResult raceResult)
        {
          if (_context.RaceResults == null)
          {
              return Problem("Entity set 'Formula1APIContext.RaceResults'  is null.");
          }
            _context.RaceResults.Add(raceResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaceResult", new { id = raceResult.Id }, raceResult);
        }

        // DELETE: api/RaceResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceResult(int id)
        {
            if (_context.RaceResults == null)
            {
                return NotFound();
            }
            var raceResult = await _context.RaceResults.FindAsync(id);
            if (raceResult == null)
            {
                return NotFound();
            }

            _context.RaceResults.Remove(raceResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceResultExists(int id)
        {
            return (_context.RaceResults?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
