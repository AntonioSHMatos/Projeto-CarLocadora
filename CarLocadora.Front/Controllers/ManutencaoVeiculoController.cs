using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CarLocadora.Front.Controllers
{
    public class ManutencaoVeiculoController : Controller
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly IApiToken _apiToken;
        private readonly HttpClient _httpClient;
        public ManutencaoVeiculoController(IApiToken apiToken, IOptions<DadosBase> dadosBase, IHttpClientFactory httpClient)
        {
            _apiToken = apiToken;
            _dadosBase = dadosBase;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<ActionResult> Index()
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await  response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<ManutencaoVeiculoModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }
          
        

        public async Task<IActionResult> Create()
        {
            ViewBag.Veiculos = await CarregarVeiculos();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] ManutencaoVeiculoModel manutencao)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await  _apiToken.Obter());


                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo", manutencao);

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


        // GET: VeiculoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo/ObterUmaManutencao?id={id}");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Veiculos = await CarregarVeiculos();

                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<ManutencaoVeiculoModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] ManutencaoVeiculoModel manutencaoVeiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo", manutencaoVeiculo);

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



        public  async Task<ActionResult> Delete(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), new { mensagem = "Registro excluído!", sucesso = true });
            }
            else
            {
                throw new Exception("Ligue Para o Dev!");
            }
        }



        private async Task<List<SelectListItem>> CarregarVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                List<VeiculoModel> veiculos = JsonConvert.DeserializeObject<List<VeiculoModel>>(conteudo);

                foreach (var linha in veiculos)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Placa.ToString(),
                        Text = linha.Placa + " - " + linha.Modelo,
                        Selected = false,
                    });
                }

                return lista;
            }
            else            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
