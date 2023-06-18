using AppWebUnisuam.Collections;
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
                TempData["MensagemErro"] = "Usuário não encontrado";
                return RedirectToAction("Index", "Login");
            }

            if (CriptografiaService.EncriptaPassword(request.Senha) != usuario.Senha)
            {
                TempData["MensagemErro"] = "Senha incorreta";
                return RedirectToAction("Index", "Login");
            }

            var token = TokenService.GenerateTokenJwt(usuario, DateTime.Now.AddHours(3));
            var userId = _context.Cadastro.FirstOrDefault(e => e.Email == request.Email).Id;

            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true
            });

            Response.Cookies.Append("userid", userId.ToString(), new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true
            });


            if (usuario.Perfil == "Admin" || usuario.Perfil == "MASTER")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index_Vendedor", "Home");
            }
        }

    }
}
