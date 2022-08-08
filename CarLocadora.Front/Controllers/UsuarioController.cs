using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ProjetoArquitetura.Front.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", new ApiToken(_dadosBase, _loginRespostaModel).Obter());

            // HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Funcionario/ObterTodosFuncionarios").Result;
            HttpResponseMessage response = client.GetAsync($"https://localhost:1433/api/Usuario").Result;
            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<UsuarioModel>>(conteudo));
            }
            else
            {
                throw new Exception("DEU RUIM! LIGUE PARA O DEV!");
            }
        }
    }

}

