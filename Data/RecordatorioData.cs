using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class RecordatorioData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para enviar recordatorio
        public async Task SendRecordatorio(RecordatorioModel recordatorio)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("sendRecordatorio", sql))
                {
                    //store.CommandType = CommandType.StoredProcedure;
                    //store.Parameters.AddWithValue("name", client.name);
                    //store.Parameters.AddWithValue("address", client.address);
                    //store.Parameters.AddWithValue("telephoneNumber", client.telephoneNumber);
                    //store.Parameters.AddWithValue("email", client.email);
                    //store.Parameters.AddWithValue("active", client.active);

                    //await sql.OpenAsync();
                    //await store.ExecuteNonQueryAsync();
                }
            }
        }
       
    }
}
