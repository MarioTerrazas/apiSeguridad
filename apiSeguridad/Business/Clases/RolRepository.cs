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

    public class RolRepository : IRolRepository
    {
        private readonly string connec;
        public RolRepository(IConfiguration _IConfiguration)
        {
            connec = _IConfiguration.GetConnectionString("conBase");
        }
        public async Task<List<Rol>> GetList()
        {
            List<Rol> list = new List<Rol>();
            Rol l;
            using (SqlConnection conn = new SqlConnection(connec))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Rol; ", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new Rol();
                        l.Id = Convert.ToInt32(reader["Id"]);
                        l.NombreRol = Convert.ToString(reader["NombreRol"]);
                        
                        list.Add(l);
                    }
                }
            }
            return list;
        }

        public async Task<Rol> AgregaActualiza(Rol l, string t)
        {
            using (SqlConnection conn = new SqlConnection(connec))
            {
                string cadena = "";
                if (t == "c")
                    cadena = "set @I=(select isnull(max(Id),0)+1 from Rol)" +
                    "insert into Rol(NombreRol) values(@NombreRol)";
                if (t == "u")
                {
                    cadena = "update Rol set NombreRol=@NombreRol where Id=@Id; ";
                    
                }
                using (SqlCommand cmd = new SqlCommand(cadena, conn))
                {
                    SqlParameter Result = new SqlParameter("@I", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(Result);
                    cmd.Parameters.AddWithValue("@Id", l.Id);
                    cmd.Parameters.AddWithValue("@NombreRol", l.NombreRol);                    
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    if (t == "c")
                        l.Id = int.Parse(Result.Value.ToString());
                }
            }
            return l;
        }

    }
}