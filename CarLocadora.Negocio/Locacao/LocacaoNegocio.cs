using CarLocadora.Entity;
using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Locacao
{
    public class LocacaoNegocio : ILocacaoNegocio
    {
        private readonly Context _context;

        public LocacaoNegocio(Context context)
        {
            _context = context;
        }
        public async Task Alterar(LocacaoModel locacao)
        {
            locacao.DataAlteracao = DateTime.Now;
            _context.Update(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(LocacaoModel locacao)
        {
            locacao.DataInclusao = DateTime.Now;
            await _context.AddAsync(locacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LocacaoModel>> ObterLista()
        {
            return await _context.LocacaoVeiculos.ToListAsync();
        }
        public async Task<LocacaoModel> ObterUmaLocacao(int id)
        {
            return await _context.LocacaoVeiculos.SingleOrDefaultAsync(x => x.Id == id);
        }
    }

}
