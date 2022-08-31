using CarLocadora.Database;
using CarLocadora.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Negocio.Login
{
    public class LoginNegocio : ILoginNegocio
    {
        public async Task<LoginRespostaModel> Login(LoginRequisicaoModel loginRequisicaoModel)
        {
            LoginRespostaModel loginRespostaModel = new LoginRespostaModel();
            loginRespostaModel.Autenticado = false;
            loginRespostaModel.Usuario = loginRequisicaoModel.Usuario;
            loginRespostaModel.Token = "";
            loginRespostaModel.DataExpiracao = null;

            if (loginRequisicaoModel.Usuario == "UsuarioDevPratica" && loginRequisicaoModel.Senha == "SenhaDevPratica")
            {
                loginRespostaModel = new GeradorToken().GerarToken(loginRespostaModel);
            }
            return loginRespostaModel;
        }


    }
}
