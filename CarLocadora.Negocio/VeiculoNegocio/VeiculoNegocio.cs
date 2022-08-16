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
            _context.Update(veiculo);
            _context.SaveChangesAsync();
        }

        public void Inserir(VeiculoModel veiculo)
        {
            _context.Update(veiculo);
            _context.SaveChangesAsync();
        }

        public List<VeiculoModel> ObterLista()
        {
            return _context.Veiculo.ToList();
        }
    }
}
