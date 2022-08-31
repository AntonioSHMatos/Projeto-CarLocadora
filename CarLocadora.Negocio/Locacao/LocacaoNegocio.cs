using CarLocadora.Entity;
using CarLocadora.Models.Models;
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
        public void Alterar(LocacaoModel locacao)
        {
            locacao.DataAlteracao = DateTime.Now;
            _context.Update(locacao);
            _context.SaveChanges();
        }

        public void Inserir(LocacaoModel locacao)
        {
            locacao.DataInclusao = DateTime.Now;
            _context.Add(locacao);
            _context.SaveChanges();
        }

        public List<LocacaoModel> ObterLista()
        {
            return _context.LocacaoVeiculos.ToList();
        }
        public LocacaoModel ObterUmaLocacao(int id)
        {
            return _context.LocacaoVeiculos.SingleOrDefault(x => x.Id == id);
        }
    }

}
