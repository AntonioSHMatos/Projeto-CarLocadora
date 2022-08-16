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
            _context.Update(usuario);
            _context.SaveChangesAsync();
        }



        public void Inserir(UsuarioModel usuario)
        {
            _context.Update(usuario);
            _context.SaveChangesAsync();
        }

        public List<UsuarioModel> ObterLista()
        {
            return _context.Usuario.ToList();
        }
    }
}
