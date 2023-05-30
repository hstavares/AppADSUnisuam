using System;
namespace AppWebUnisuam.Models
{
    public class Token
    {
        public string UserId { get; set; }
        public string Login { get; set; }
        public DateTime Exp { get; set; }
    }
}
