using CarLocadora.Comum.Models;
using CarLocadora.Entity;
using CarLocadora.infra.RabbitMQFactory;
using CarLocadora.Negocio.Categoria;
using CarLocadora.Negocio.Cliente;
using CarLocadora.Negocio.FormaPagamento;
using CarLocadora.Negocio.Locacao;
using CarLocadora.Negocio.Login;
using CarLocadora.Negocio.ManutencaoVeiculo;
using CarLocadora.Negocio.RabbitMQ;
using CarLocadora.Negocio.Usuario;
using CarLocadora.Negocio.VeiculoNegocio.cs;
using CarLocadora.Negocio.Vistoria;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;

namespace CarLocadora.API.ServicoExtensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
          {

              c.SwaggerDoc("v1", new OpenApiInfo
              {
                  Title = "Nome",
                  Version = "v1",
                  Description = "Descrição",
              });

              c.EnableAnnotations();

              var securityScheme = new OpenApiSecurityScheme
              {
                  Name = "Autenticacao JWT",
                  Description = "Informe o token JTW Bearer **_somente_**",
                  In = ParameterLocation.Header,
                  Type = SecuritySchemeType.Http,
                  Scheme = "bearer",
                  BearerFormat = "JWT",
                  Reference = new OpenApiReference
                  {
                      Id = JwtBearerDefaults.AuthenticationScheme,
                      Type = ReferenceType.SecurityScheme
                  }
              };
              c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
              c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
      {securityScheme, Array.Empty<string>() }
          });
          });
        }

        public static void ConfigurarJWT(this IServiceCollection services)
        {
            Environment.SetEnvironmentVariable("JWT_SECRETO",
              Convert.ToBase64String(new HMACSHA256().Key), EnvironmentVariableTarget.Process);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = "EmitenteDoJWT",
                    ValidAudience = "DestinatarioDoJWT",
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Environment.GetEnvironmentVariable("JWT_SECRETO")))
                };
            });
        }

        public static void ConfigurarServicos(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "Data Source=localhost,1433;User ID=sa;Password=senha@1234xxxy;Initial Catalog=DBCarLocadora;";
            services.AddDbContext<Context>(opt => opt.UseSqlServer(connectionString));

            
            services.AddScoped<ILoginNegocio, LoginNegocio>();
            services.AddScoped<ICategoriaNegocio, CategoriaNegocio>();
            services.AddScoped<IVeiculoNegocio, VeiculoNegocio>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IFormaPagamentoNegocio, FormaPagamentoNegocio>();
            services.AddScoped<IClienteNegocio, ClienteNegocio>();
            services.AddScoped<IManutencaoVeiculoNegocio, ManutencaoVeiculoNegocio>();
            services.AddScoped<IVistoriaNegocio, VistoriaNegocio>();
            services.AddScoped<ILocacaoNegocio, LocacaoNegocio>();


            services.Configure<DadosBaseRabbitMQ>(configuration.GetSection("DadosBaseRabbitMQ"));
            services.AddScoped<IRabbitMQNegocio, RabbitMQNegocio>();
            services.AddSingleton<RabbitMQFactory>();
        }
    }



}
