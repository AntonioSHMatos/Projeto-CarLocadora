using CarLocadora.Comum.Models;
using CarLocadora.GerarArquivo;
using CarLocadora.infra.RabbitMQFactory;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {

        services.Configure<DadosBaseRabbitMQ>(hostContext.Configuration.GetSection("DadosBaseRabbitMQ"));
        services.AddSingleton<RabbitMQFactory>();

        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();
