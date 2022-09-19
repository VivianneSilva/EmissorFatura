using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cadastroCliente.Data;
using cadastroCliente.Models;

namespace cadastroCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estadoCivilsController : ControllerBase
    {
        private readonly cadastroClienteContext _context;

        public estadoCivilsController(cadastroClienteContext context)
        {
            _context = context;
        }

        // GET: api/estadoCivils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<estadoCivil>>> GetestadoCivils()
        {
            return await _context.estadoCivils.ToListAsync();
        }

        // GET: api/estadoCivils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<estadoCivil>> GetestadoCivil(int id)
        {
            var estadoCivil = await _context.estadoCivils.FindAsync(id);

            if (estadoCivil == null)
            {
                return NotFound();
            }

            return estadoCivil;
        }

        // PUT: api/estadoCivils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutestadoCivil(estadoCivil estadoCivil)
        {
            _context.estadoCivils.Update(estadoCivil);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/estadoCivils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<estadoCivil>> PostestadoCivil(estadoCivil estadoCivil)
        {
            _context.estadoCivils.Add(estadoCivil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetestadoCivil", new { id = estadoCivil.estadoCivilId }, estadoCivil);
        }

        // DELETE: api/estadoCivils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteestadoCivil(int id)
        {
            var estadoCivil = await _context.estadoCivils.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            _context.estadoCivils.Remove(estadoCivil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool estadoCivilExists(int id)
        {
            return _context.estadoCivils.Any(e => e.estadoCivilId == id);
        }
    }
}
