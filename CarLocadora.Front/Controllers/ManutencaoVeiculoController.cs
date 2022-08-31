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
        public ManutencaoVeiculoController(IApiToken apiToken, IOptions<DadosBase> dadosBase)
        {
            _apiToken = apiToken;
            _dadosBase = dadosBase;
        }



        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<ManutencaoVeiculoModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }
        }






        
        public ActionResult Details(string id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<ManutencaoVeiculoModel>(conteudo));
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
        public ActionResult Create([FromForm] ManutencaoVeiculoModel manutencao)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


                    HttpResponseMessage response = client.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo", manutencao).Result;

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
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo/ObterUmaManutencao?id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Veiculos = CarregarVeiculos().Result;

                string conteudo = response.Content.ReadAsStringAsync().Result;
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
        public ActionResult Edit([FromForm] ManutencaoVeiculoModel manutencaoVeiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

                    HttpResponseMessage response = client.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo", manutencaoVeiculo).Result;

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



        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());
            HttpResponseMessage response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}ManutencaoVeiculo?id={id}").Result;
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

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

            HttpResponseMessage response = client.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo").Result;

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
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
