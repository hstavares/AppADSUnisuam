using AppWebUnisuam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppWebUnisuam.Data;

namespace AppWebUnisuam.Controllers
{
    public class NotasFiscaisController : Controller
    {
        private readonly AppWebUnisuamContext _context;

        public NotasFiscaisController(AppWebUnisuamContext context)
        {
            _context = context;
        }
    }
}
