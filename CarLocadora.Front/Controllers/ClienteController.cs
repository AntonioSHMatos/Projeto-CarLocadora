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
    public class ClienteController : Controller
    {
        private readonly IOptions<DadosBase> _dadosbase;
        private readonly IApiToken _apiToken;
        public ClienteController(IOptions<DadosBase> dadosbase, IApiToken apiToken)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
        }
        // GET: ClienteController
        public async Task<ActionResult> Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Cliente");

            
            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<ClienteModel>>(conteudo));
            }
            else
            {
                throw new Exception(" LIGUE PARA O DEV!");
            }
        }
       



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] ClienteModel cliente)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Cliente", cliente);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }


        public async Task<ActionResult> Edit(string cpf)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Cliente/ObterUmCliente?cpf={cpf}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<ClienteModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Cliente", cliente);

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


