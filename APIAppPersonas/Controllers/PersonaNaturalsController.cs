using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAppPersonas.Modelos;

namespace APIAppPersonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaNaturalsController : ControllerBase
    {
        private readonly AppPersonasContext _context;

        public PersonaNaturalsController(AppPersonasContext context)
        {
            _context = context;
        }

        // GET: api/PersonaNaturals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaNatural>>> GetPersonaNaturals()
        {
            return await _context.PersonaNaturals.ToListAsync();
        }

        // GET: api/PersonaNaturals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaNatural>> GetPersonaNatural(int id)
        {
            var personaNatural = await _context.PersonaNaturals.FindAsync(id);

            if (personaNatural == null)
            {
                return NotFound();
            }

            return personaNatural;
        }

        // PUT: api/PersonaNaturals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaNatural(int id, PersonaNatural personaNatural)
        {
            if (id != personaNatural.Identificacion)
            {
                return BadRequest();
            }

            _context.Entry(personaNatural).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaNaturalExists(id))
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

        // POST: api/PersonaNaturals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaNatural>> PostPersonaNatural(PersonaNatural personaNatural)
        {
            _context.PersonaNaturals.Add(personaNatural);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaNaturalExists(personaNatural.Identificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonaNatural", new { id = personaNatural.Identificacion }, personaNatural);
        }

        // DELETE: api/PersonaNaturals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaNatural(int id)
        {
            var personaNatural = await _context.PersonaNaturals.FindAsync(id);
            if (personaNatural == null)
            {
                return NotFound();
            }

            _context.PersonaNaturals.Remove(personaNatural);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaNaturalExists(int id)
        {
            return _context.PersonaNaturals.Any(e => e.Identificacion == id);
        }
    }
}
