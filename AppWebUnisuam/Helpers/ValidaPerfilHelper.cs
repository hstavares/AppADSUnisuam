using AppWebUnisuam.Data;

namespace AppWebUnisuam.Helpers
{
    public class ValidaPerfilHelper
    {
        public static bool Get(PerfilType[] perfis, string IdUsuario, AppWebUnisuamContext _context)
        {

            var usuarioProjetoPerfis = _context.UsuarioProjetoPerfil
                 .Include(e => e.Usuarios)
                 .Include(e => e.Projetos)
                 .Include(e => e.Perfil)
                 .Where(e => e.Usuarios.Id == IdUsuario);

            if (usuarioProjetoPerfis == null) //usuario n encontrado
                return false;

            if (perfis == null) //nao é feita validacao por perfil
                return true;

            foreach (var perfil in perfis)
            {
                foreach (var item in usuarioProjetoPerfis)
                {
                    if (item.Perfil.Nome.ToUpper() == perfil.ToString().ToUpper() || item.Perfil.Nome.ToUpper() == "MASTER")
                        return true;
                }
            }

            return false;
        }
    }
}
