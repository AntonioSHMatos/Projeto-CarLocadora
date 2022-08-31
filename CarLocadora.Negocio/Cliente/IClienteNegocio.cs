using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Cliente
{
    public interface IClienteNegocio
    {
        List<ClienteModel> ObterLista();
        void Alterar(ClienteModel cliente);
        void Inserir(ClienteModel cliente);
        ClienteModel ObterUmCliente(string cpf);
    }
}
