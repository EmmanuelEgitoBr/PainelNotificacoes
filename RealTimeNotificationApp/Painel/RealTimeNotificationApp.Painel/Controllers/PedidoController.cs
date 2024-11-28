using Microsoft.AspNetCore.Mvc;

namespace RealTimeNotificationApp.Painel.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConsultarPedido()
        {
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
