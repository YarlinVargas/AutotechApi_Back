using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class UsuarioData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para insertar usuario
        public async Task<ReplyLogin> InsertarUsuario(UsuarioModel user)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                ReplyLogin r = new ReplyLogin();
                try
                {
                    using (var store = new SqlCommand("insertarUsuario", sql))
                    {
                        store.CommandType = CommandType.StoredProcedure;
                        store.Parameters.AddWithValue("name", user.name);
                        store.Parameters.AddWithValue("birthday", user.birthday);
                        store.Parameters.AddWithValue("age", user.age);
                        store.Parameters.AddWithValue("address", user.address);
                        store.Parameters.AddWithValue("email", user.email);
                        store.Parameters.AddWithValue("password", user.password);
                        store.Parameters.AddWithValue("idUserType", user.idusserType);
                        store.Parameters.AddWithValue("active", user.active);

                        await sql.OpenAsync();
                        await store.ExecuteNonQueryAsync();
                        r.Message = "Usuario Creado con exito";
                        r.Flag = true;
                        return r;
                    }
                }
                catch (Exception ex)
                {
                    r.Message = "Creacion de usuario invalido";
                    r.Flag = false;
                    return r;
                }
            }
        }
        //Metodo para editar usuarios
        public async Task EditarUsuario(UsuarioModel user)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("editarUsuario", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id", user.Id_user);
                    store.Parameters.AddWithValue("name", user.name);
                    store.Parameters.AddWithValue("birthday", Convert.ToDateTime(user.birthday).ToString("yyyy-MM-dd")); 
                    store.Parameters.AddWithValue("age", user.age);
                    store.Parameters.AddWithValue("address", user.address);
                    store.Parameters.AddWithValue("email", user.email);
                    store.Parameters.AddWithValue("password", user.password);
                    store.Parameters.AddWithValue("idUserType", user.idusserType);
                    store.Parameters.AddWithValue("active", user.active);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para eliminar usuarios
        public async Task EliminarUsuario(UsuarioModel user)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("eliminarUsuario", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id_user", user.Id_user);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para mostrar lista de usuarios
        public async Task<ActionResult<List<UsuarioModel>>> MostrarCliente()
        {
            var list = new List<UsuarioModel>();

            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("mostrarUsuario", sql))
                {
                    await sql.OpenAsync();
                    store.CommandType = CommandType.StoredProcedure;
                    using (var item = await store.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var musuario = new UsuarioModel();
                            musuario.Id_user = (int)item["id_user"];
                            musuario.name = (string)item["name"];
                            musuario.birthday = (string)item["birthday"];
                            musuario.age = (int)item["age"];
                            musuario.address = (string)item["address"];
                            musuario.email = (string)item["email"];
                            musuario.password = (string)item["password"];
                            musuario.idusserType = (int)item["idUserType"];

                            list.Add(musuario);
                        }
                    }
                }
            }
            return list;
        }
    }
}
