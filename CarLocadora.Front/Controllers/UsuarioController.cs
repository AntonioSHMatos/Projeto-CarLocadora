using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IOptions<DadosBase> _dadosbase;
        private readonly IApiToken _apiToken;
        public UsuarioController(IOptions<DadosBase> dadosbase, IApiToken apiToken)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
        }
        // GET: UsuarioController
        public ActionResult Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Usuario").Result;
            // HttpResponseMessage response = client.GetAsync($"https://localhost:44357/api/Usuario").Result;
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

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Usuario").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<UsuarioModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


                HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Usuario", usuario).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    throw new Exception("LIGUE PARA O DEV!");
                }
            }

            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(string cpf)
        {
            if (ModelState.IsValid)
            {

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


                HttpResponseMessage response = client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Usuario/ObterUmUsuario?cpf={cpf}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = response.Content.ReadAsStringAsync().Result;
                    return View(JsonConvert.DeserializeObject<UsuarioModel>(conteudo));
                }
                else
                {
                    throw new Exception("LIGUE PARA O DEV!");
                }
            }
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Usuario", usuario).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw new Exception("LIGUE PARA O DEV!");
                    }

                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
