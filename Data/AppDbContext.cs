using APITarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace APITarefas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<AtividadeModel> atividade { get; set; }
        public DbSet<TipoAtividadeModel> tipo_atividade { get; set; }
    }
}
