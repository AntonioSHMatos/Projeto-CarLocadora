﻿using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Usuario
{
    public interface IUsuarioNegocio
    {
        void Alterar(UsuarioModel usuario);
        void Inserir(UsuarioModel usuario);

       

    }
}
