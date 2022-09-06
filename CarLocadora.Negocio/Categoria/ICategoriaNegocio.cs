using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Categoria
{
    public interface ICategoriaNegocio
    {
        Task Excluir(int Id);
        Task<List<CategoriaModel>> ObterLista();
               
        Task Alterar(CategoriaModel categoria);
        Task  Inserir(CategoriaModel categoria);
        Task<CategoriaModel> ObterUmaCategoria(int id);
    }
}
