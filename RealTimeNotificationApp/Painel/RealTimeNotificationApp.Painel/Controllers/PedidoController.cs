using Microsoft.AspNetCore.Mvc;
using RealTimeNotificationApp.Painel.Models;
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

        public IActionResult Index()
        {
            return View();
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

        public IActionResult CadastrarPedido()
        {
            return View();
        }

        public IActionResult AlterarStatus()
        {
            return View();
        }
    }
}
