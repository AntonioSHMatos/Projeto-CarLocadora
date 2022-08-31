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

        public void Alterar(CategoriaModel categoria)
        {
            categoria.DataAlteracao = DateTime.Now;
            _context.Update(categoria);
            _context.SaveChanges();

            
        }

        public void Excluir(int Id)
        {
            CategoriaModel categoria =  _context.Categoria.SingleOrDefault(x => x.Id == Id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
        }

        public void Inserir(CategoriaModel categoria)
        {
            categoria.DataInclusao = DateTime.Now;
            _context.AddAsync(categoria);
           _context.SaveChanges();
        }

        public List<CategoriaModel> ObterLista()
        {
            return _context.Categoria.ToList();
        }
        

        public CategoriaModel ObterUmaCategoria(int id)
        {
            return _context.Categoria.SingleOrDefault(x => x.Id == id);
        }
    }
}
