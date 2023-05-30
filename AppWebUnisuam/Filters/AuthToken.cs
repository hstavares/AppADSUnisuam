using AppWebUnisuam.Collections;
using AppWebUnisuam.Data;
using Microsoft.EntityFrameworkCore;
using AppWebUnisuam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AppWebUnisuam.Helpers;

namespace AppWebUnisuam.Filters
{
    public class AuthToken : Attribute, IAuthorizationFilter
    {
        public PerfilType[] perfilTypes { get; set; }

        public AuthToken(params PerfilType[] perfis)
        {
            perfilTypes = perfis;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenstr = context.HttpContext.Request.Headers.FirstOrDefault(e => e.Key == "Authorization").Value;

            if (string.IsNullOrEmpty(tokenstr))
                context.Result = new UnauthorizedResult();

            var _context = context.HttpContext.RequestServices.GetService(typeof(AppWebUnisuamContext)) as AppWebUnisuamContext;

            if (!string.IsNullOrEmpty(tokenstr))
            {
                var token = TokenService.RevertTokenJwt(tokenstr);
                bool valid = false;

                if (token != null)
                {
                    if (token.Exp < DateTime.Now)
                    {
                        //token expirado
                        context.Result = new UnauthorizedResult();
                    }
                    else
                    {
                        var us = _context.Cadastro.FirstOrDefault(e => e.Email == token.Login);
                            


                        if (perfilTypes.Any())
                        {
                            var isAdmin = (us.Perfil == "MASTER" || us.Perfil == "Admin") ? true : false;

                            if (isAdmin)
                            {
                                valid = true;
                            }
                            else
                            {
                                var validaPerfil = ValidaPerfilHelper.Get(perfilTypes, token.UserId, _context);

                                if (validaPerfil)
                                {
                                    valid = true;
                                }
                            }

                            if (!valid)
                                context.Result = new UnauthorizedResult();
                        }
                        else
                        {
                            valid = true;
                        }

                    }
                }
                else
                {
                    //token incorreto
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                //token vazio
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
