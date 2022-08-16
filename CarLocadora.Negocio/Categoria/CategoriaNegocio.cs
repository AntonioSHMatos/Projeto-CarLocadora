using CarLocadora.Entity;
using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Categoria
{
    public class CategoriaNegocio : ICategoriaNegocio
    {

        private readonly Context _context;

        public CategoriaNegocio(Context context)
        {
            _context = context;
        }

        public void Alterar(CategoriaModel categoriaNegocio)
        {
            _context.Update(categoriaNegocio);
            _context.SaveChangesAsync();
        }

        public void Excluir(int Id)
        {
            CategoriaModel categoria =  _context.Categoria.SingleOrDefault(x => x.Id == Id);
            _context.Categoria.Remove(categoria);
            _context.SaveChangesAsync();
        }

        public void Inserir(CategoriaModel categoriaNegocio)
        {
            _context.AddAsync(categoriaNegocio);
            _context.SaveChangesAsync();
        }

        public List<CategoriaModel> ObterLista()
        {
            return _context.Categoria.ToList();
        }
    }
}
