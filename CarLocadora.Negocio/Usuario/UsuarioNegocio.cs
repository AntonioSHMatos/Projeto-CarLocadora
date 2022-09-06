using CarLocadora.Entity;
using CarLocadora.Models.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task Alterar(UsuarioModel usuario)
        {

            usuario.DataAlteracao = DateTime.Now;
             _context.Update(usuario);
            await _context.SaveChangesAsync();
        }



        public async Task Inserir(UsuarioModel usuario)
        {
            usuario.DataInclusao = DateTime.Now;
             await _context.AddAsync(usuario);
             await _context.SaveChangesAsync();
        }

        public async Task<List<UsuarioModel>> ObterLista()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> ObterUmUsuario(string CPF)
        {
            return await  _context.Usuario.SingleOrDefaultAsync(x => x.CPF == CPF);
        }
    }
}
