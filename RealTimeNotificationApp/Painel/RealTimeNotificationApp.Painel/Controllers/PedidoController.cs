using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealTimeNotificationApp.Painel.Models;
using RealTimeNotificationApp.Painel.Services;
using RealTimeNotificationApp.Painel.Services.Interfaces;

namespace RealTimeNotificationApp.Painel.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IApiService _apiService;

        public PedidoController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult ConsultarPedido()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConsultarPedido(string orderNumber)
        {
            if (ModelState.IsValid)
            {
                if (orderNumber == null) { return NotFound(); }

                CompleteOrderModel model = await _apiService.GetCompleteOrder(orderNumber);

                if(model.Entrega == null || model.Pedido == null) { return View(); }
                
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CadastrarPedido()
        {
            CarregarListaUFs();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPedido(OrderModel model)
        {
            CarregarListaUFs();

            if (ModelState.IsValid)
            {
                if (model == null) { return View(); }

                CompleteOrderModel result = await _apiService.CreateOrder(model);

                if (result.Pedido == null || result.Entrega == null) { return View(); }

                return RedirectToAction(nameof(Index), "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AlterarStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AlterarStatus(UpdateStatusModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null) { return View(); }

                var result = await _apiService.UpdateStatus(model);

                if (result) { return RedirectToAction(nameof(Index), "Home"); }

                return View();
            }
            return View();
        }

        private void CarregarListaUFs()
        {
            ViewBag.Estados = BrazilianStatesService.GetEstados().Select(c => new SelectListItem()
            { Text = c.Name, Value = c.Abreviation }).ToList();
        }
    }
}
