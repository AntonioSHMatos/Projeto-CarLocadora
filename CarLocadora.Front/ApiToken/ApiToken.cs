using CarLocadora.Front.ApiToken;
using CarLocadora.Front.Models;
using CarLocadora.Models.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Servico
{
    public class ApiToken :IApiToken

    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IOptions<LoginRespostaModel> _loginRespostaModel;
        public ApiToken(IOptions<DadosBase> dadosBase, IOptions<LoginRespostaModel> loginRespostaModel)
        {
            _dadosBase = dadosBase;
            _loginRespostaModel = loginRespostaModel;
        }

        private void ObterToken()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            LoginRequisacaoModel loginRequisacaoModel = new LoginRequisacaoModel();
            loginRequisacaoModel.Usuario = "UsuarioDevPratica";
            loginRequisacaoModel.Senha = "SenhaDevPratica";



            HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Login", loginRequisacaoModel).Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                LoginRespostaModel loginRespostaModel = JsonConvert.DeserializeObject<LoginRespostaModel>(conteudo);

                if (loginRespostaModel.Autenticado == true)
                {
                    _loginRespostaModel.Value.Autenticado = loginRespostaModel.Autenticado;
                    _loginRespostaModel.Value.Usuario = loginRespostaModel.Usuario;
                    _loginRespostaModel.Value.DataExpiracao = loginRespostaModel.DataExpiracao;
                    _loginRespostaModel.Value.Token = loginRespostaModel.Token;

                }
            }
            else
            {
                throw new Exception("LIGUE P/ O DEV!");
            }
        }
        public string Obter()
        {
            if (_loginRespostaModel.Value.Autenticado == false)
            {
                ObterToken();
            }
            else
            {
                if (DateTime.Now >= _loginRespostaModel.Value.DataExpiracao)
                {
                    ObterToken();
                }
            }
            return _loginRespostaModel.Value.Token;
        }
    }
}
