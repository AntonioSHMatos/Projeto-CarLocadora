using CarLocadora.Entity;
using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Vistoria
{
    public class VistoriaNegocio : IVistoriaNegocio
    {
        private readonly Context _context;

        public VistoriaNegocio(Context context)
        {
            _context = context;
        }

        public async Task Alterar(VistoriaModel vistoria)
        {
            vistoria.DataAlteracao = DateTime.Now;
            _context.Update(vistoria);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(VistoriaModel vistoria)
        {
            vistoria.DataInclusao = DateTime.Now;
            await _context.AddAsync(vistoria);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VistoriaModel>> ObterLista()
        {

            return await _context.Vistoria.ToListAsync();
        }

        public async Task<VistoriaModel> ObterUmaVistoria(int id)
        {
            return _context.Vistoria.SingleOrDefault(x => x.Id == id);
        }
    }
}
