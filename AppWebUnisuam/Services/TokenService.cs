using AppWebUnisuam.Models;
using JWT.Algorithms;
using JWT.Builder;
using System.Text.Json;
namespace AppWebUnisuam.Services
{
    public static class TokenService
    {
        static string Key => "@Projeto_ADS_Unisuam_Hugo_Igor@";

        public static string GenerateTokenJwt(Cadastro user, DateTime expiration)
        {
            var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                      .WithSecret(Key)
                      .AddClaim("Exp", expiration)
                      .AddClaim("Login", user.Email)
                      .AddClaim("UserId", user.Id.ToString());


            return token.Encode();
        }

        public static Token RevertTokenJwt(string token)
        {
            try
            {
                var json = JwtBuilder.Create()
                     .WithAlgorithm(new HMACSHA256Algorithm()) // symmetric
                     .WithSecret(Key)
                     .MustVerifySignature()
                     .Decode(token);

                var obj = JsonSerializer.Deserialize<Token>(json);
                return obj;
            }
            catch (Exception e)
            {
                return default;
            }

        }
    }
}
