using api_tarefas.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using api_tarefas.Data;

namespace api_tarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<api_tarefasContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("api_tarefasContext") ?? throw new InvalidOperationException("Connection string 'api_tarefasContext' not found.")));

            // Add services to the container.
            builder.Services.AddDbContext<TarefaContexto>(opt =>
            {
                opt.UseInMemoryDatabase("TarefasLista");
            });
           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}