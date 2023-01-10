using Microsoft.EntityFrameworkCore;
using Tarefas.Models;

namespace Tarefas.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options):base(options) 
        {
        

        }

        public DbSet<CadastroModel> cadastroModels { get; set; }

    }
}
