using AppWebUnisuam.Collections;
using AppWebUnisuam.Data;

namespace AppWebUnisuam.Helpers
{
    public class ValidaPerfilHelper
    {
        public static bool Get(PerfilType[] perfis, string IdUsuario, AppWebUnisuamContext _context)
        {

            var usuarioPerfis = _context.Cadastro
                 .Where(e => e.Id == IdUsuario);

            if (usuarioPerfis == null) //usuario n encontrado
                return false;

            if (perfis == null) //nao é feita validacao por perfil
                return true;

            foreach (var perfil in perfis)
            {
                foreach (var item in usuarioPerfis)
                {
                    if (item.Perfil.ToUpper() == perfil.ToString().ToUpper() || item.Nome.ToUpper() == "MASTER")
                        return true;
                }
            }

            return false;
        }
    }
}
