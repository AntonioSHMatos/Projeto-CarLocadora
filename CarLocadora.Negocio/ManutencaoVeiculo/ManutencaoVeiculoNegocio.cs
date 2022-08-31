using CarLocadora.Entity;
using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.ManutencaoVeiculo
{
    public class ManutencaoVeiculoNegocio : IManutencaoVeiculoNegocio
    {
        private readonly Context _context;

        public ManutencaoVeiculoNegocio(Context context)
        {
            _context = context;
        }
        public void Alterar(ManutencaoVeiculoModel manutencaoVeiculo)
        {
            manutencaoVeiculo.DataAlteracao = DateTime.Now;
            _context.Update(manutencaoVeiculo);
            _context.SaveChanges();
        }

        public void Excluir(int Id)
        {
            ManutencaoVeiculoModel manutencaoVeiculo = _context.ManutencaoVeiculos.SingleOrDefault(x => x.Id == Id);
            _context.ManutencaoVeiculos.Remove(manutencaoVeiculo);
            _context.SaveChanges();
        }

        public void Inserir(ManutencaoVeiculoModel manutencaoVeiculo)
        {
            manutencaoVeiculo.DataInclusao = DateTime.Now;
            _context.Add(manutencaoVeiculo);
            _context.SaveChanges();
        }

        public List<ManutencaoVeiculoModel> ObterLista()
        {
            return _context.ManutencaoVeiculos.ToList();

        }

        public ManutencaoVeiculoModel ObterUmaManutencao(int id)
        {
            return _context.ManutencaoVeiculos.SingleOrDefault(x => x.Id == id);
        }
    }
}
