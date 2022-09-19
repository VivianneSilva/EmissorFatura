using Microsoft.EntityFrameworkCore;
using cadastroCliente.Models;

namespace cadastroCliente.Data
{
    public class cadastroClienteContext : DbContext  
    {
        public cadastroClienteContext(DbContextOptions<cadastroClienteContext> options)
            : base(options)
        {

        }
        public DbSet<cadastroCliente.Models.cliente> Cliente { get; set; }
        public DbSet<cadastroCliente.Models.estadoCivil> estadoCivils { get; set; }
        public DbSet<cadastroCliente.Models.Produto> Produto { get; set; }

    }
}
