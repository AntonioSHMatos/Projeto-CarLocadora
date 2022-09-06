using CarLocadora.Entity;
using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task Alterar(ManutencaoVeiculoModel manutencaoVeiculo)
        {
            manutencaoVeiculo.DataAlteracao = DateTime.Now;
            _context.Update(manutencaoVeiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int Id)
        {
            ManutencaoVeiculoModel manutencaoVeiculo = await _context.ManutencaoVeiculos.SingleOrDefaultAsync(x => x.Id == Id);
            _context.ManutencaoVeiculos.Remove(manutencaoVeiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(ManutencaoVeiculoModel manutencaoVeiculo)
        {
            manutencaoVeiculo.DataInclusao = DateTime.Now;
            await _context.AddAsync(manutencaoVeiculo);
           await  _context.SaveChangesAsync();
        }

        public async Task<List<ManutencaoVeiculoModel>> ObterLista()
        {
            return await _context.ManutencaoVeiculos.ToListAsync();

        }

        public async Task<ManutencaoVeiculoModel> ObterUmaManutencao(int id)
        {
            return await _context.ManutencaoVeiculos.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
