using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoMateProjectShare.Hubs;

namespace YoMateProjectShare.Controllers
{
    public class MessagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            return View("Index", username);
        }
    }
}
