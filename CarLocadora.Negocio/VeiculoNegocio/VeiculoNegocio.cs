using CarLocadora.Entity;
using CarLocadora.Models.Models;
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
        public VeiculoNegocio(Context context)
        {
            _context = context;
        }
        public void Alterar(VeiculoModel veiculo)
        {
            veiculo.DataAlteracao = DateTime.Now;
             _context.Update(veiculo);
             _context.SaveChanges();
        }

        public void Inserir(VeiculoModel veiculo)
        {

            veiculo.DataInclusao = DateTime.Now;
             _context.Add(veiculo);
             _context.SaveChanges();
        }

        public List<VeiculoModel> ObterLista()
        {
            return _context.Veiculo.ToList();
        }

        public VeiculoModel ObterUmVeiculo(string placa)
        {
            return _context.Veiculo.SingleOrDefault(x => x.Placa == placa);
        }
    }
}
