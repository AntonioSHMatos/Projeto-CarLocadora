﻿using CarLocadora.Entity;
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
            _context.Update(cliente);
            _context.SaveChangesAsync();
        }

        public void Inserir(ClienteModel cliente)
        {
            _context.AddAsync(cliente);
            _context.SaveChangesAsync();
        }

        public List<ClienteModel> ObterLista()
        {
            return _context.Cliente.ToList();
        }
    }
}
