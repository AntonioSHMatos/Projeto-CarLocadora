using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLocadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    { 
        public ActionResult Index()
        {
            List<VeiculoModel> veiculos = new VeiculoDB().ObterTodosVeiculos();
            return View(veiculos);
        }

        
        public ActionResult Details(string placa)
        {
            VeiculoModel veiculo = new VeiculoDB().ObterDadoDoVeiculo(placa);
            return View(veiculo);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] VeiculoModel veiculosModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new VeiculoDB().InserirDadosDoVeiculo(veiculosModel);
                    return RedirectToAction(nameof(Index), new { mensagem = "Registro criado!", sucesso = true });
                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu " + ex.Message;

                return View();
            }
        }

       
        public ActionResult Edit(string placa)
        {
            VeiculoModel veiculos = new VeiculoDB().ObterDadoDoVeiculo(placa);

            return View(veiculos);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] VeiculoModel veiculosModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    new VeiculoDB().AlterarDadosDoVeiculo(veiculosModel);
                    return RedirectToAction(nameof(Index), new { mensagem = "Registro editado!", sucesso = true });
                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }

            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu " + ex.Message;

                return View();
            }
        }

       
        public ActionResult Delete(string placa)
        {
            try
            {
                new VeiculoDB().DeletarVeiculo(placa);
                return RedirectToAction(nameof(Index), new { mensagem = "Registro deletado!", sucesso = true });
            }
            catch (Exception ex)
            {
                TempData["erro"] = $"Não foi possivel excluir o veiculo " + ex.Message;

                return View();
            }
        }

       
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





    
