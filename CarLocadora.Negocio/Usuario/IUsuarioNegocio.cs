using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Usuario
{
    public interface IUsuarioNegocio
    {
        Task Alterar(UsuarioModel usuario);
        Task Inserir(UsuarioModel usuario);

        Task<List<UsuarioModel>> ObterLista();

        Task<UsuarioModel> ObterUmUsuario(string CPF);
    }
}
