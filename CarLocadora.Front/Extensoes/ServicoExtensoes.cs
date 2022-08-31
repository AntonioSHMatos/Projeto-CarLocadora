
using CarLocadora.Front.Servico;
using CarLocadora.Models.Models;

namespace CarLocadora.Front.ServicoExtensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarServicos(this IServiceCollection services)
        {
              services.AddSingleton<IApiToken, ApiToken>();
              services.AddSingleton<LoginRespostaModel>();
        }



    }
}
