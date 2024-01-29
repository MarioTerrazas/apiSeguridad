using apiSeguridad.Business.Contracts;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using apiSeguridad.Models;

namespace apiSeguridad.Business.Clases
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connec;
        public UsuarioRepository(IConfiguration _IConfiguration)
        {
            connec = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<Usuario> GetNombreUsuario(string nombreusuario)
        {
            List<string> list = new List<string>();
            Usuario oUsuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(connec))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from trnUsuario where NombreUsuario='"
                    + nombreusuario + "';", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"].ToString());
                        oUsuario.NombreUsuario = reader["NombreUsuario"].ToString();
                        oUsuario.Clave = reader["Clave"].ToString();
                        oUsuario.Salt = reader["Salt"].ToString();
                    }
                }
            }
            return oUsuario;
        }
        public async Task<List<Usuario>> GetList()
        {
            List<Usuario> list = new List<Usuario>();
            Usuario l;
            using (SqlConnection conn = new SqlConnection(connec))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from trnUsuario; ", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new Usuario();
                        l.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        l.NombreUsuario = Convert.ToString(reader["NombreUsuario"]);
                        
                        list.Add(l);
                    }
                }
            }
            return list;
        }

        public async Task<Usuario> AgregaActualiza(Usuario l, string t)
        {
            using (SqlConnection conn = new SqlConnection(connec))
            {
                string cadena = "";
                if (t == "c")
                    cadena = "set @I=(select isnull(max(Id),0)+1 from Usuarioes)" +
                    "insert into Usuarioes(NombreUsuario) values(@NombreUsuario)";
                if (t == "u")
                {
                    cadena = "update trnUsuario set NombreUsuario=@NombreUsuario where Id=@Id; ";
                    
                }
                using (SqlCommand cmd = new SqlCommand(cadena, conn))
                {
                    SqlParameter Result = new SqlParameter("@I", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(Result);
                    cmd.Parameters.AddWithValue("@Id", l.IdUsuario);
                    cmd.Parameters.AddWithValue("@NombreUsuario", l.NombreUsuario);                    
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    if (t == "c")
                        l.IdUsuario = int.Parse(Result.Value.ToString());
                }
            }
            return l;
        }
      
    }
}