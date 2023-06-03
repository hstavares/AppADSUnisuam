using AppWebUnisuam.Data;
using AppWebUnisuam.DTO.Requests;
using AppWebUnisuam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebUnisuam.Controllers
{
    public class LoginController : Controller
    {

        public AppWebUnisuamContext _context { get; set; }

        public LoginController(AppWebUnisuamContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Login(LoginRequest request)
        {
            var usuario = _context.Cadastro.FirstOrDefault(e => e.Email == request.Email);

            if (usuario == null)
            {
                return BadRequest();
            }
            else
            {
                
                //usuario.Senha = CriptografiaService.EncriptaPassword(request.Senha);
                return RedirectToAction("Privacy", "Home");
            }
        }

    }
}
