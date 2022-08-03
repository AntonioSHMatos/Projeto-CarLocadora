﻿using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet()]
        public List<ClienteModel> Get()
        {   
            List<ClienteModel> listadeclientes = new List<ClienteModel>();

            ClienteModel clienteModel = new();


            clienteModel.Nome = "cidadão anonimo";
            clienteModel.CNH = "000.000.000.00";

            listadeclientes.Add(clienteModel);

            return listadeclientes;
        }
    }
}
