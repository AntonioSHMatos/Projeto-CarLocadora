using CarLocadora.Entity;
using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Usuario
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly Context _context;
        public UsuarioNegocio(Context context)
        {
            _context = context;
        }
        public void Alterar(UsuarioModel usuario)
        {

            usuario.DataAlteracao = DateTime.Now;
             _context.Update(usuario);
             _context.SaveChanges();
        }



        public void Inserir(UsuarioModel usuario)
        {
            usuario.DataInclusao = DateTime.Now;
             _context.Add(usuario);
             _context.SaveChanges();
        }

        public List<UsuarioModel> ObterLista()
        {
            return _context.Usuario.ToList();
        }

        public UsuarioModel ObterUmUsuario(string CPF)
        {
            return _context.Usuario.SingleOrDefault(x => x.CPF == CPF);
        }
    }
}
