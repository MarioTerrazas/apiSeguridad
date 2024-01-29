using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiSeguridad.Models;

namespace apiSeguridad.Business.Contracts
{

    public interface IUsuarioRepository
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
        Task<List<Usuario>> GetList();
        Task<Usuario> AgregaActualiza(Usuario l, string t);
        
    }
}