using CarLocadora.Comum.Models;
using CarLocadora.Comum.Servico;
using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class LocacaoController : Controller
    {

        private readonly IOptions<DadosBase> _dadosbase;
        private readonly IApiToken _apiToken;
        private readonly HttpClient _httpClient;

        public LocacaoController(IOptions<DadosBase> dadosbase, IApiToken apiToken, IHttpClientFactory httpClient)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index(string mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Locacao");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<LocacaoModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }

        }


        public async Task<ActionResult> Create()
        {

            ViewBag.Veiculos = CarregarVeiculos().Result;
            ViewBag.Clientes = CarregarClientes().Result;
            ViewBag.FormasDePagamentos = await CarregarFormasDePagamento();

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] LocacaoModel locacao)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Locacao", locacao);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }


        public async Task<ActionResult> Edit(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await  _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Locacao/ObterUmaLocacao?id={id}");

            if (response.IsSuccessStatusCode)
            {


                ViewBag.Veiculos = await CarregarVeiculos();
                ViewBag.Clientes = await CarregarClientes();
                ViewBag.FormasDePagamentos = await CarregarFormasDePagamento();

                string conteudo = response.Content.ReadAsStringAsync().Result;

                return View(JsonConvert.DeserializeObject<LocacaoModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] LocacaoModel locacao)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Locacao", locacao);

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
        private async Task<List<SelectListItem>> CarregarVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Veiculo");

            if (response.IsSuccessStatusCode)
            {
                List<VeiculoModel> veiculos = JsonConvert.DeserializeObject<List<VeiculoModel>>(response.Content.ReadAsStringAsync().Result);

                foreach (var linha in veiculos)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Placa,
                        Text = linha.Modelo + " - " + linha.Marca,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        private async Task<List<SelectListItem>> CarregarClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}Cliente");

            if (response.IsSuccessStatusCode)
            {
                List<ClienteModel> Clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(response.Content.ReadAsStringAsync().Result);

                foreach (var linha in Clientes)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.CPF,
                        Text = linha.Nome + " - " + linha.CPF,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        private async Task<List<SelectListItem>> CarregarFormasDePagamento()
        {
            List<SelectListItem> lista = new List<SelectListItem>();


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosbase.Value.API_URL_BASE}FormaPagamento");

            if (response.IsSuccessStatusCode)
            {
                List<FormaPagamentoModel> formasPagamento = JsonConvert.DeserializeObject<List<FormaPagamentoModel>>( response.Content.ReadAsStringAsync().Result);

                foreach (var linha in formasPagamento)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.Descricao,
                        Selected = false,
                    });
                }

                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}





