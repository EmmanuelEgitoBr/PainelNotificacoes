using Microsoft.AspNetCore.Mvc;

namespace RealTimeNotificationApp.Painel.Controllers
{
    public class PainelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
