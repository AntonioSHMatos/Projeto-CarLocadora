using CarLocadora.Entity;
using CarLocadora.Models.Models;
using CarLocadora.Negocio.Cliente;
using CarLocadora.Negocio.VeiculoNegocio.cs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
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
    }
}







