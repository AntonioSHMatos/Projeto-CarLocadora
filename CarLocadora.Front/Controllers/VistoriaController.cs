using CarLocadora.Front.Models;
using CarLocadora.Front.Servico;
using CarLocadora.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class VistoriaController : Controller
    {

        private readonly IOptions<DadosBase> _dadosbase;
        private readonly IApiToken _apiToken;

        public VistoriaController(IOptions<DadosBase> dadosbase, IApiToken apiToken)
        {
            _dadosbase = dadosbase;
            _apiToken = apiToken;
        }
        // GET: CategoriaController
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


            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Vistoria");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<VistoriaModel>>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }

        }
       



        public ActionResult Create()
        {

            ViewBag.Locacoes = CarregarLocacoes().Result;
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] VistoriaModel vistoria)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await  _apiToken.Obter());


            HttpResponseMessage response =  await client.PostAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Vistoria", vistoria);

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
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());


            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Vistoria/ObterUmaVistoria?id={id}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<VistoriaModel>(conteudo));
            }
            else
            {
                throw new Exception("LIGUE PARA O DEV!");
            }



            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] VistoriaModel vistoria)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await client.PutAsJsonAsync($"{_dadosbase.Value.API_URL_BASE}Vistoria", vistoria);

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

        private async Task<List<SelectListItem>> CarregarLocacoes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  await _apiToken.Obter());

            HttpResponseMessage response = await client.GetAsync($"{_dadosbase.Value.API_URL_BASE}Locacao");

            if (response.IsSuccessStatusCode)
            {
                List<LocacaoModel> locacoes = JsonConvert.DeserializeObject<List<LocacaoModel>>( response.Content.ReadAsStringAsync().Result);

                foreach (var linha in locacoes)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.VeiculoPlaca + " - " + linha.ClienteCPF,
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


