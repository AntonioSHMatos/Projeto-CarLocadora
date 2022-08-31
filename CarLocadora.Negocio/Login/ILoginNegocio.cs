using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Login
{
    public interface ILoginNegocio
    {
        Task<LoginRespostaModel> Login(LoginRequisicaoModel loginRequisicaoModel);




    }


}
