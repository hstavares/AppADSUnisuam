using System.Security.Cryptography;
using System.Text;

namespace AppWebUnisuam.Services
{
    public static class CriptografiaService
    {

        public static string EncriptaPassword(this string password)
        {

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            string hashPass = sBuilder.ToString();

            return hashPass;

        }

        public static string Encoda64(string data)
        {
            var encodeBytes = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(encodeBytes);
        }

        public static string DecodeBase64(string data)
        {
            var valueBytes = Convert.FromBase64String(data);
            return Encoding.UTF8.GetString(valueBytes);
        }


    }
}
