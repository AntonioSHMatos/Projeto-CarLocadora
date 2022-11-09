using CarLocadora.infra.RabbitMQFactory;
using CarLocadora.Models.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using System.Net;
using System.Net.Mail;

namespace CarLocadora.GerarArquivo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RabbitMQFactory _rabbitMQFactory;

        public Worker(ILogger<Worker> logger, RabbitMQFactory rabbitMQFactory)
        {
            _logger = logger;
            _rabbitMQFactory = rabbitMQFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                var canal = _rabbitMQFactory.GetChannel();

                while (true)
                {
                    BasicGetResult retorno = canal.BasicGet("NovosVeiculos", false);
                    if (retorno == null)
                    {
                        break;
                    }
                    else
                    {
                        var dados = JsonConvert.DeserializeObject<VeiculoModel>(Encoding.UTF8.GetString(retorno.Body.ToArray()));

                        // await EnviarEmail(dados.Email, dados.Nome);

                        GerarArquivo(dados);

                        canal.BasicAck(retorno.DeliveryTag, true);
                    }
                }

                await Task.Delay(35000, stoppingToken);
            }
        }


        private void GerarArquivo (VeiculoModel veiculo)
        {
            StreamWriter sw = new StreamWriter($"C:\\Teste\\{veiculo.Placa}.txt");

            sw.WriteLine(veiculo.Placa);
            sw.WriteLine(veiculo.Chassi);
            sw.WriteLine(veiculo.Marca);
            sw.WriteLine(veiculo.Modelo);
            sw.WriteLine(veiculo.Combustivel);
            sw.WriteLine(veiculo.Cor);
            sw.WriteLine(veiculo.Opcionais);
            sw.WriteLine(veiculo.Ativo);
            sw.WriteLine(veiculo.DataInclusao);
            sw.WriteLine(veiculo.DataAlteracao);
            sw.WriteLine(veiculo.CategoriaId);
            sw.Close();



               
        }
    }
}
