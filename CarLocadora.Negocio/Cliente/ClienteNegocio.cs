using CarLocadora.Entity;
using CarLocadora.Models.Models;
using CarLocadora.Negocio.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CarLocadora.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly IRabbitMQNegocio _rabbitMQNegocio;
        private readonly Context _context;

        public ClienteNegocio(Context context, IRabbitMQNegocio rabbitMQNegocio)
        {
            _context = context;
            _rabbitMQNegocio = rabbitMQNegocio;
        }

        public void Alterar(ClienteModel cliente)
        {
            cliente.DataAlteracao = DateTime.Now;
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Inserir(ClienteModel cliente)
        {
            cliente.DataInclusao = DateTime.Now;
            _context.AddAsync(cliente);
            _context.SaveChanges();

            _rabbitMQNegocio.PublicarMensagem(cliente, "", "NovosClientes");
        }

        public List<ClienteModel> ObterLista()
        {
            return _context.Cliente.ToList();
        }


        public ClienteModel ObterUmCliente(string cpf)
        {
            return _context.Cliente.SingleOrDefault(x => x.CPF == cpf);

        }

        public List<ClienteModel> ObterListaEnviarEmail()
        {
            return _context.Cliente.Where(x => x.Email != null && x.emailEnviado.Equals(false)).ToList();
        }

        public async Task AlterarEnvioEmail(string cpf)
        {
            //var cliente = await ObterPorCPF(cpf);
            var cliente = await _context.Cliente.FirstAsync(x => x.CPF.Equals(cpf));
            cliente.emailEnviado = true;
        }
    }
}