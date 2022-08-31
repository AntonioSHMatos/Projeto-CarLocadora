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
        void Excluir(int Id);
        List<CategoriaModel> ObterLista();
               
        void Alterar(CategoriaModel categoria);
        void Inserir(CategoriaModel categoria);
        CategoriaModel ObterUmaCategoria(int id);
    }
}
