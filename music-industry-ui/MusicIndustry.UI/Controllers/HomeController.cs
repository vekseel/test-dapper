using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MusicIndustry.UI.Models;

namespace MusicIndustry.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
