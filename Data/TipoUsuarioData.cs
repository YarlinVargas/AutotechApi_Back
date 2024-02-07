using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class TipoUsuarioData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para insertar tipos de usuarios
        public async Task InsertarTipoUsuario(TipoUsuarioModel typeUser)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("insertarTipoUsuario", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("active", typeUser.active);
                    store.Parameters.AddWithValue("description", typeUser.description);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para editar los tipos de usuarios
        public async Task EditarTipoUsuario(TipoUsuarioModel typeUser)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("editarTipousuario", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("description", typeUser.description);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para eliminar los tipos de usuarios
        public async Task EliminarTipoUsuario(TipoUsuarioModel typeUser)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("eliminarTipoUsuario", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id", typeUser.Id_userType);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para mostrar lista de los tipos de usuarios
        public async Task<ActionResult<List<TipoUsuarioModel>>> MostrarTipoUsuario()
        {
            var list = new List<TipoUsuarioModel>();

            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("mostrarTipoUsuario", sql))
                {
                    await sql.OpenAsync();
                    store.CommandType = CommandType.StoredProcedure;
                    using (var item = await store.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipoUsuario = new TipoUsuarioModel();
                            mtipoUsuario.Id_userType = (int)item["id_userType"];
                            mtipoUsuario.description = (string)item["description"];

                            list.Add(mtipoUsuario);
                        }
                    }
                }
            }
            return list;
        }
    }
}
