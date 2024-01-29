using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiSeguridad.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Salt { get; set; }
    }
}
