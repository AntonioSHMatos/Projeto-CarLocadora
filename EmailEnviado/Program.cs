using CarLocadora.Comum.Models;
using CarLocadora.Comum.Servico;
using CarLocadora.infra.RabbitMQFactory;
using CarLocadora.Models.Models;
using EmailEnviado;
using Microsoft.Extensions.Configuration;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<DadosBaseRabbitMQ>(hostContext.Configuration.GetSection("DadosBaseRabbitMQ"));
        services.AddSingleton<RabbitMQFactory>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
