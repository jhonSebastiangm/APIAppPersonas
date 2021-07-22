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
    public class PersonaJuridicasController : ControllerBase
    {
        private readonly AppPersonasContext _context;

        public PersonaJuridicasController(AppPersonasContext context)
        {
            _context = context;
        }

        // GET: api/PersonaJuridicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaJuridica>>> GetPersonaJuridicas()
        {
            return await _context.PersonaJuridicas.ToListAsync();
        }

        // GET: api/PersonaJuridicas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaJuridica>> GetPersonaJuridica(int id)
        {
            var personaJuridica = await _context.PersonaJuridicas.FindAsync(id);

            if (personaJuridica == null)
            {
                return NotFound();
            }

            return personaJuridica;
        }

        // PUT: api/PersonaJuridicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonaJuridica(int id, PersonaJuridica personaJuridica)
        {
            if (id != personaJuridica.Nit)
            {
                return BadRequest();
            }

            _context.Entry(personaJuridica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaJuridicaExists(id))
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

        // POST: api/PersonaJuridicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonaJuridica>> PostPersonaJuridica(PersonaJuridica personaJuridica)
        {
            _context.PersonaJuridicas.Add(personaJuridica);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonaJuridicaExists(personaJuridica.Nit))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonaJuridica", new { id = personaJuridica.Nit }, personaJuridica);
        }

        // DELETE: api/PersonaJuridicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonaJuridica(int id)
        {
            var personaJuridica = await _context.PersonaJuridicas.FindAsync(id);
            if (personaJuridica == null)
            {
                return NotFound();
            }

            _context.PersonaJuridicas.Remove(personaJuridica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonaJuridicaExists(int id)
        {
            return _context.PersonaJuridicas.Any(e => e.Nit == id);
        }
    }
}
