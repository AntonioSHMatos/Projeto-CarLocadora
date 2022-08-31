using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;
namespace CarLocadora.Entity
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //options.Configuration.LazyLoadingEnabled = false;
        }


        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<FormaPagamentoModel> FormaPagamento { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<VeiculoModel> Veiculo { get; set; }
        public DbSet<ManutencaoVeiculoModel> ManutencaoVeiculos { get; set; }
        public DbSet<LocacaoModel> LocacaoVeiculos { get; set; }
        public DbSet<VistoriaModel> Vistoria { get; set; }

    }
}

