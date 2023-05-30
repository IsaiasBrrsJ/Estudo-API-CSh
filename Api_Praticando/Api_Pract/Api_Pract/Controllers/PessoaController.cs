using Api_Pract.Context;
using Api_Pract.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Pract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PessoaController([FromServices] DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAllAsync()
        {

            var pessoas = await _dataContext.Pessoas.ToListAsync();

            return pessoas is null ? NotFound(new {Empty ="Nada Encontrado"}) : pessoas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetIdAsync([FromRoute] int id)
        {
            var pessoas = await _dataContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

            return pessoas is null ? NotFound(new { Empty = "Nada Encontrado" }) : pessoas;
        }

        [HttpPost]
        public async Task<ActionResult> PostPersonAsync([FromBody] Pessoa pessoa)
        {
            if(pessoa != null)
            {
                await _dataContext.Pessoas.AddAsync(pessoa);
                _dataContext.SaveChangesAsync().Wait();

                return RedirectToRoute(GetIdAsync(pessoa.Id));
            }

            return BadRequest(new { Erro = "Erro ao tentar cadastrar" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonAsync([FromRoute] int id,  Pessoa PessoaUpdate)
        {
           
            Pessoa person = await _dataContext.Pessoas.FirstOrDefaultAsync(p => p.Id == id);

            if (person != null)
            {
                person.Nome = PessoaUpdate.Nome;
                person.Sobrenome = PessoaUpdate.Sobrenome;
                person.Idade = PessoaUpdate.Idade;

                _dataContext.Entry(person).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();

                return Ok(new {Update ="Atualizado com sucesso"});
            }

            return BadRequest(new { Erro = "Erro ao tentar atualizar" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var person = await _dataContext.Pessoas.FirstOrDefaultAsync(x => x.Id == id);

            if(person != null)
            {
                _dataContext.Remove(person);
                await _dataContext.SaveChangesAsync();

                return NoContent();
            }

            return BadRequest(new { Erro = "Erro ao tentar deletar" });

        }
    }
}
