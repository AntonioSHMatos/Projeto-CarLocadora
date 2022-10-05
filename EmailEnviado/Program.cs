using CarLocadora.Comum.Models;
using CarLocadora.Comum.Servico;
using CarLocadora.Models.Models;
using EmailEnviado;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        services.AddHttpClient();
        services.AddSingleton<IApiToken, ApiToken>();
        services.Configure<DadosBase>(hostContext.Configuration.GetSection("DadosBase"));
        services.AddSingleton<LoginRespostaModel>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
