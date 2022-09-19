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
    public class clientesController : ControllerBase
    {
        private readonly cadastroClienteContext _context;

        public clientesController(cadastroClienteContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cliente>>> GetCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cliente>> Getcliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcliente(int id, cliente cliente)
        {
            if (id != cliente.clienteId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
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

        // POST: api/clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<cliente>> Postcliente(cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcliente", new { id = cliente.clienteId }, cliente);
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clienteExists(int id)
        {
            return _context.Cliente.Any(e => e.clienteId == id);
        }
    }
}
