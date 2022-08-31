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
            HttpResponseMessage response = client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Cliente").Result;

            
            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<ClienteModel>>(conteudo));
            }
            else
            {
                throw new Exception(" LIGUE PARA O DEV!");
            }
        }
        public ActionResult Details(string cpf)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Cliente").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<ClienteModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }

            return View();
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ClienteModel cliente)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Cliente", cliente).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }


        public ActionResult Edit(string cpf)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Cliente/ObterUmCliente?cpf={cpf}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
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
        public ActionResult Edit([FromForm] ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Cliente", cliente).Result;

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


        public ActionResult Delete(string cpf)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string cpf, IFormCollection collection)
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


