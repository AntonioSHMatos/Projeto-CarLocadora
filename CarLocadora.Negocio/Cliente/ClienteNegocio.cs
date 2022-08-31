using CarLocadora.Entity;
using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Cliente
{
    public class ClienteNegocio : IClienteNegocio
    {
        private readonly Context _context;
        public ClienteNegocio(Context context)
        {
            _context = context;
        }
        public void Alterar(ClienteModel cliente)
        {
            cliente.DataAlteracao = DateTime.Now;
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Inserir(ClienteModel cliente)
        {
            cliente.DataInclusao = DateTime.Now;
             _context.AddAsync(cliente);
             _context.SaveChanges();
        }

        public List<ClienteModel> ObterLista()
        {
            return _context.Cliente.ToList();
        }
        public ClienteModel ObterUmCliente(string cpf)
        {            
            return _context.Cliente.SingleOrDefault(x => x.CPF == cpf);
            
        }
    }
}

