using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_tarefas.Model;
using api_tarefas.Contexto;

namespace api_tarefas.Data
{
    public class api_tarefasContext : DbContext
    {
        public api_tarefasContext (DbContextOptions<TarefaContexto> options)
            : base(options)
        {
        }

        public DbSet<api_tarefas.Model.TarefaItem> TarefaItem { get; set; } = default!;
    }
}
