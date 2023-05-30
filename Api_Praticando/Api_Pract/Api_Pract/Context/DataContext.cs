using Api_Pract.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Pract.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option)
            : base(option) { }


        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
