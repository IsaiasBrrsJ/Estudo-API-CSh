using api_tarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace api_tarefas.Contexto
{
    public class TarefaContexto : DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto> options) 
            : base(options) { }

        public DbSet<TarefaItem> Tarefas { get; set; } = null!; 
 
    }
}
