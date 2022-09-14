
using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{

    public class CategoriaController : Controller
    {
        private readonly IOptions<DadosBase> _dadosbase;
        private readonly IApiToken _apiToken;
        private readonly HttpClient _httpClient;

        public CategoriaController(IOptions<DadosBase> dadosbase, IApiToken apiToken,IHttpClientFactory httpClient)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: CategoriaController
        public async Task<IActionResult> Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Categoria");

            if (response.IsSuccessStatusCode)
            {

                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<CategoriaModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }

        }
        



        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoriaModel categoria)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await  _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Categoria", categoria);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Categoria/ObterDadosCategoria?id={id}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<CategoriaModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }



            return View();
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] CategoriaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {



                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Categoria", categoria);

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

        public async Task<IActionResult> Delete(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_dadosbase.Value.API_URL_BASE}Categoria?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), new { mensagem = "Registro excluído!", sucesso = true });
            }
            else
            {
                throw new Exception("Ligue Para o Dev!");
            }
        }
    }
}
