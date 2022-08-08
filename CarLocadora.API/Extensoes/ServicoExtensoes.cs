using CarLocadora.Entity;
using CarLocadora.Negocio.Categoria;
using CarLocadora.Negocio.Cliente;
using CarLocadora.Negocio.FormaPagamento;
using CarLocadora.Negocio.Usuario;
using CarLocadora.Negocio.VeiculoNegocio.cs;
using Microsoft.EntityFrameworkCore;

namespace CarLocadora.API.Extensoes
{
    public static class ServicoExtensoes
    {


        public static void ConfigurarServicos(this IServiceCollection services)
        {

            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234xxxy;Initial Catalog=DBCarLocadora;";

            services.AddDbContext<Context>(opt => opt.UseSqlServer(connectionString));


            services.AddScoped<IClienteNegocio, ClienteNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IFormaPagamentoNegocio, FormaPagamentoNegocio>();
            services.AddScoped<ICategoriaNegocio, CategoriaNegocio>();
            services.AddScoped<IVeiculoNegocio, VeiculoNegocio>();

        }
    }

}
