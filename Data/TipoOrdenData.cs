using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class TipoOrdenData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para insertar tipos de ordenes de trabajo
        public async Task InsertarTipoOrden(TipoOrdenTrabajoModel type)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("insertarTipoOrden", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("description", type.description);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para editar los tipos de ordenes de trabajo
        public async Task EditarTipoOrden (TipoOrdenTrabajoModel type)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("editarClient", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("description", type.description);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para eliminar los tipos de ordenes de trabajo
        public async Task EliminarTipoOrden(TipoOrdenTrabajoModel type)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("eliminarTipoOrden", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id", type.Id_orden_trabajo);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para mostrar lista de los tipos de ordenes de trabajo
        public async Task<ActionResult<List<TipoOrdenTrabajoModel>>> MostrarTipoOrden()
        {
            var list = new List<TipoOrdenTrabajoModel>();

            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("mostrarTipoOrden", sql))
                {
                    await sql.OpenAsync();
                    store.CommandType = CommandType.StoredProcedure;
                    using (var item = await store.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipoOrden= new TipoOrdenTrabajoModel();
                            mtipoOrden.Id_orden_trabajo = (int)item["id_orden_trabajo"];
                            mtipoOrden.description = (string)item["description"];

                            list.Add(mtipoOrden);
                        }
                    }
                }
            }
            return list;
        }
    }
}
