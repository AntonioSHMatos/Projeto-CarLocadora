using CarLocadora.infra.RabbitMQFactory;
using CarLocadora.Models.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailEnviado
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
                    BasicGetResult retorno = canal.BasicGet("NovosClientes", false);
                    if (retorno == null)
                    {
                        break;
                    }
                    else
                    {
                        var dados = JsonConvert.DeserializeObject<ClienteModel>(Encoding.UTF8.GetString(retorno.Body.ToArray()));

                        await EnviarEmail(dados.Email, dados.Nome);

                        canal.BasicAck(retorno.DeliveryTag, true);
                    }
                }

                await Task.Delay(35000, stoppingToken);
            }
        }

        private async Task EnviarEmail(string email, string nome)
        {
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("turma1@devpratica.com.br");
            mensagem.To.Add(email);
            mensagem.Subject = "Bem Vindo";
            mensagem.IsBodyHtml = true;
            mensagem.Body = EmailBoasVindas(nome);

            var smtpCliente = new SmtpClient("smtp.kinghost.net")
            {
                Port = 587,
                Credentials = new NetworkCredential("turma1@devpratica.com.br", "Senha@senha10"),
                EnableSsl = false,

            };
            smtpCliente.Send(mensagem);

        }

        private string EmailBoasVindas(string nome)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>Parabéns <b>{nome},</b></p>");
            sb.Append($"<p>Seja muito bem-vindo a <b>CAR-LOCADORA.</b></p>");
            sb.Append($"<p>Estamos muito felizes de você fazer parte da <b>CAR-LOCADORA</b>.</p>");
            sb.Append($"<br>");
            sb.Append($"<p>Grande abraço</p>");
            return sb.ToString();

        }
    }
}