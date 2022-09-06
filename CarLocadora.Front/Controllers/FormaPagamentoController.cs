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
    public class FormaPagamentoController : Controller
    {

        private readonly IOptions<DadosBase> _dadosbase;
        private readonly IApiToken _apiToken;
        public FormaPagamentoController(IOptions<DadosBase> dadosbase, IApiToken apiToken)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
        }
        // GET: FormaPagamentoController
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


            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}FormaPagamento");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<FormaPagamentoModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }

        

        // GET: FormaPagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPagamentoController/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] FormaPagamentoModel pagamento)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await client.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}FormaPagamento", pagamento);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }

        // GET: FormaPagamentoController/Edit/5
        public  async Task<ActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await  _apiToken.Obter());


            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}FormaPagamento/ObterUmPagamento?id={id}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<FormaPagamentoModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }

        // POST: FormaPagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] FormaPagamentoModel pagamento)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}FormaPagamento", pagamento);

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
