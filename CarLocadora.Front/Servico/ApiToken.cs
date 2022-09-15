
using CarLocadora.Front.Models;
using CarLocadora.Models.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Servico
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

        private async Task  ObterToken()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            LoginRequisicaoModel loginRequisacaoModel = new LoginRequisicaoModel();
            loginRequisacaoModel.Usuario = "UsuarioDevPratica";
            loginRequisacaoModel.Senha = "SenhaDevPratica";



            HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Login", loginRequisacaoModel);

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
        public async Task<string> Obter()
        {
            if (_loginRespostaModel.Value.Autenticado == false)
            {
                await ObterToken();
            }
            else
            {
                if (DateTime.Now >= _loginRespostaModel.Value.DataExpiracao)
                {
                    await ObterToken();
                }
            }
            return _loginRespostaModel.Value.Token;
        }
    }
}
