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
        private readonly HttpClient _httpClient;
        public UsuarioController(IOptions<DadosBase> dadosbase, IApiToken apiToken, IHttpClientFactory httpClient)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: UsuarioController
        public async Task<ActionResult> Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Usuario").Result;
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

       
        

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Usuario", usuario);

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
        public async Task<ActionResult> Edit(string cpf)
        {
            if (ModelState.IsValid)
            {


                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


                HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Usuario/ObterUmUsuario?cpf={cpf}");

                if (response.IsSuccessStatusCode)
                {
                    string conteudo = await response.Content.ReadAsStringAsync();
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
        public async Task<ActionResult> Edit([FromForm] UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Usuario", usuario);

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

       
    }
}
