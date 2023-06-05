using AppWebUnisuam.Collections;
using AppWebUnisuam.Data;
using AppWebUnisuam.Filters;
using AppWebUnisuam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppWebUnisuam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppWebUnisuamContext _context;

        public HomeController(ILogger<HomeController> logger, AppWebUnisuamContext context)
        {
            _logger = logger;
            _context = context;
        }
        [AuthToken(PerfilType.Admin)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sair()
        {
            Response.Cookies.Delete("AuthToken");

            return RedirectToAction("Index", "Login");
        }
        [AuthToken(PerfilType.Vendedor)]
        public async Task<IActionResult> Index_Vendedor()
        {
            return _context.Produtos != null ?
                          View(await _context.Produtos.ToListAsync()) :
                          Problem("Entity set 'AppWebUnisuamContext.Produtos'  is null.");
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
    }
}