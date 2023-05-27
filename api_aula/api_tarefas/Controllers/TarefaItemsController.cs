using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_tarefas.Data;
using api_tarefas.Model;
using api_tarefas.Contexto;

namespace api_tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaItemsController : ControllerBase
    {
        private readonly TarefaContexto _context;

        public TarefaItemsController([FromServices] TarefaContexto context)
        {
            _context = context;
        }

        // GET: api/TarefaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaItem>>> GetTarefaItem()
        {
          if (_context.Tarefas == null)
          {
              return NotFound();
          }
            return await _context.Tarefas.ToListAsync();
        }

        // GET: api/TarefaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaItem>> GetTarefaItem(long id)
        {
          if (_context.Tarefas == null)
          {
              return NotFound();
          }
            var tarefaItem = await _context.Tarefas.FindAsync(id);

            if (tarefaItem == null)
            {
                return NotFound();
            }

            return tarefaItem;
        }

        // PUT: api/TarefaItems/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefaItem(long id, TarefaItem tarefaItem)
        {
            if (id != tarefaItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaItemExists(id))
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

        // POST: api/TarefaItems
    
        [HttpPost]
        public async Task<ActionResult<TarefaItem>> PostTarefaItem(TarefaItem tarefaItem)
        {
          if (_context.Tarefas == null)
          {
              return Problem("Entity set 'api_tarefasContext.TarefaItem'  is null.");
          }
            _context.Tarefas.Add(tarefaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefaItem", new { id = tarefaItem.Id }, tarefaItem);
        }

        // DELETE: api/TarefaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaItem(long id)
        {
            if (_context.Tarefas == null)
            {
                return NotFound();
            }
            var tarefaItem = await _context.Tarefas.FindAsync(id);
            if (tarefaItem == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TarefaItemExists(long id)
        {
            return (_context.Tarefas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
