using Microsoft.AspNetCore.Mvc;
using MyStoreMVC.LocNT.Models;
using System.Diagnostics;

namespace MyStoreMVC.LocNT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CatGiauKhobau() 
        {
            HttpContext.Session.SetString("BiMat", "8h An Com");
            return Content("Cat giau kho bau thanh cong. Sang trang khac de xem");
        }

        public IActionResult XemKhoBau() 
        {
            var tinNhan = HttpContext.Session.GetString("BiMat");
            if (string.IsNullOrEmpty(tinNhan))
            {
                return Content("co cai nit Session chua tao");
            }
            return Content("ahaha: " + tinNhan);
        }


    }
}
