using CarLocadora.Entity;
using CarLocadora.Models.Models;
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

        public void Alterar(VistoriaModel vistoria)
        {
            vistoria.DataAlteracao = DateTime.Now;
            _context.Update(vistoria);
            _context.SaveChanges();
        }

        public void Inserir(VistoriaModel vistoria)
        {
            vistoria.DataInclusao = DateTime.Now;
            _context.Add(vistoria);
            _context.SaveChanges();
        }

        public List<VistoriaModel> ObterLista()
        {

            return _context.Vistoria.ToList();
        }

        public VistoriaModel ObterUmaVistoria(int id)
        {
            return _context.Vistoria.SingleOrDefault(x => x.Id == id);
        }
    }
}
