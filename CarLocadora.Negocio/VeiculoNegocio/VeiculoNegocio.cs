using CarLocadora.Entity;
using CarLocadora.Models.Models;
using CarLocadora.Negocio.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.VeiculoNegocio.cs
{
    public class VeiculoNegocio : IVeiculoNegocio
    {
        private readonly Context _context;
        private readonly IRabbitMQNegocio _rabbitMQNegocio;

        public VeiculoNegocio(Context context, IRabbitMQNegocio rabbitMQNegocio)
        {
            _context = context;
            _rabbitMQNegocio = rabbitMQNegocio;
        }
        public async Task Alterar(VeiculoModel veiculo)
        {
            veiculo.DataAlteracao = DateTime.Now;
             _context.Update(veiculo);
             await _context.SaveChangesAsync();
        }

        public async Task Inserir(VeiculoModel veiculo)
        {

            veiculo.DataInclusao = DateTime.Now;
             _context.Add(veiculo);
             await _context.SaveChangesAsync();

            _rabbitMQNegocio.PublicarMensagem(veiculo, "", "NovosVeiculos");
        }

        public async Task <List<VeiculoModel>> ObterLista()
        {
            return await _context.Veiculo.ToListAsync();
        }

        public async Task<VeiculoModel> ObterUmVeiculo(string placa)
        {
            return await _context.Veiculo.SingleOrDefaultAsync(x => x.Placa == placa);
        }
    }
}
