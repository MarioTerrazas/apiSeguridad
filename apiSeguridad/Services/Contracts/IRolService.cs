using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiSeguridad.Models;
namespace apiSeguridad.Services.Contracts
{
   public interface IRolService
    {
        Task<List<Rol>> GetList();
        Task<Rol> AgregaActualiza(Rol l, string t);
    }
}
