using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppWebUnisuam.Models;

namespace AppWebUnisuam.Data
{
    public class AppWebUnisuamContext : DbContext
    {
        public AppWebUnisuamContext (DbContextOptions<AppWebUnisuamContext> options)
            : base(options)
        {
        }

        public DbSet<AppWebUnisuam.Models.Cadastro> Cadastro { get; set; } = default!;
    }
}
