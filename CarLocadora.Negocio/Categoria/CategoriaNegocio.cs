using CarLocadora.Entity;
using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task Alterar(CategoriaModel categoria)
        {
            categoria.DataAlteracao = DateTime.Now;
            _context.Update(categoria);
            await _context.SaveChangesAsync();

            
        }

        public async Task Excluir(int Id)
        {
            CategoriaModel categoria =  _context.Categoria.SingleOrDefault(x => x.Id == Id);
             _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(CategoriaModel categoria)
        {
            categoria.DataInclusao = DateTime.Now;
           await  _context.AddAsync(categoria);
           await _context.SaveChangesAsync();
        }

        public async Task<List<CategoriaModel>> ObterLista()
        {
            return await _context.Categoria.ToListAsync();
        }
        

        public async Task<CategoriaModel> ObterUmaCategoria(int id)
        {
            return await _context.Categoria.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
