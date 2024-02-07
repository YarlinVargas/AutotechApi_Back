using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class InventarioData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para insertar clientes
        //public async Task InsertarInventario(InventarioModel inventario)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSql()))
        //    {
        //        using (var store = new SqlCommand("insertarInventario", sql))
        //        {
        //            store.CommandType = CommandType.StoredProcedure;
        //            store.Parameters.AddWithValue("name", inventario.name);
        //            store.Parameters.AddWithValue("address", inventario.address);
        //            store.Parameters.AddWithValue("telephoneNumber", inventario.telephoneNumber);
        //            store.Parameters.AddWithValue("email", inventario.email);
        //            store.Parameters.AddWithValue("active", inventario.active);

        //            await sql.OpenAsync();
        //            await store.ExecuteNonQueryAsync();
        //        }
        //    }
        //}
        ////Metodo para editar clientes
        //public async Task EditarCliente(ClienteModel client)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSql()))
        //    {
        //        using (var store = new SqlCommand("editarClient", sql))
        //        {
        //            store.CommandType = CommandType.StoredProcedure;
        //            store.Parameters.AddWithValue("name", client.name);
        //            store.Parameters.AddWithValue("address", client.address);
        //            store.Parameters.AddWithValue("telephoneNumber", client.telephoneNumber);
        //            store.Parameters.AddWithValue("email", client.email);
        //            store.Parameters.AddWithValue("active", client.active);

        //            await sql.OpenAsync();
        //            await store.ExecuteNonQueryAsync();
        //        }
        //    }
        //}
        ////Metodo para eliminar paciente 
        //public async Task EliminarCliente(ClienteModel client)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSql()))
        //    {
        //        using (var store = new SqlCommand("eliminarCliente", sql))
        //        {
        //            store.CommandType = CommandType.StoredProcedure;
        //            store.Parameters.AddWithValue("id", client.Id_cliente);

        //            await sql.OpenAsync();
        //            await store.ExecuteNonQueryAsync();
        //        }
        //    }
        //}
        ////Metodo para mostrar lista cliente
        //public async Task<ActionResult<List<ClienteModel>>> MostrarCliente()
        //{
        //    var list = new List<ClienteModel>();

        //    using (var sql = new SqlConnection(cn.cadenaSql()))
        //    {
        //        using (var store = new SqlCommand("mostrarClient", sql))
        //        {
        //            await sql.OpenAsync();
        //            store.CommandType = CommandType.StoredProcedure;
        //            using (var item = await store.ExecuteReaderAsync())
        //            {
        //                while (await item.ReadAsync())
        //                {
        //                    var mcliente = new ClienteModel();
        //                    mcliente.Id_cliente = (int)item["id_cliente"];
        //                    mcliente.name = (string)item["name"];
        //                    mcliente.address = (string)item["address"];
        //                    mcliente.telephoneNumber = (string)item["telephoneNumber"];
        //                    mcliente.email = (string)item["email"];

        //                    list.Add(mcliente);
        //                }
        //            }
        //        }
        //    }
        //    return list;
        //}
    }
}
