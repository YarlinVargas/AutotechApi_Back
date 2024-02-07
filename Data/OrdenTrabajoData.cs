using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class OrdenTrabajoData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para insertar Ordenes de Trabajo
        public async Task InsertarOrdenTrabajo(OrdenTrabajoModel orden)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("insertarOrdenTrabajo", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("description", orden.description);
                    store.Parameters.AddWithValue("status", orden.status);
                    store.Parameters.AddWithValue("idUser", orden.idUser);
                    store.Parameters.AddWithValue("idOrdentype", orden.idOrdenType);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para editar ordenes de trabajo
        public async Task EditarOrdenTrabajo(OrdenTrabajoModel orden)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("editarOrdenTrabajo", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("description", orden.description);
                    store.Parameters.AddWithValue("status", orden.status);
                    store.Parameters.AddWithValue("idUser", orden.idUser);
                    store.Parameters.AddWithValue("idOrdentype", orden.idOrdenType);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para eliminar orden de trabajo
        public async Task EliminarOrdenTrabajo(OrdenTrabajoModel orden)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("eliminarOrdenTrabajo", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id_orden_trabajo", orden.Id_oder_trabajo);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para mostrar lista de las ordenes de trabajo
        public async Task<ActionResult<List<OrdenTrabajoModel>>> MostrarOrdenTrabajo()
        {
            var list = new List<OrdenTrabajoModel>();

            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("mostrarOrdenTrabajo", sql))
                {
                    await sql.OpenAsync();
                    store.CommandType = CommandType.StoredProcedure;
                    using (var item = await store.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var morden = new OrdenTrabajoModel();
                            morden.Id_oder_trabajo = (int)item["id_orden_trabajo"];
                            morden.description = (string)item["description"];
                            morden.idUser = (int)item["idUser"];
                            morden.idOrdenType = (int)item["idOrdenType"];

                            list.Add(morden);
                        }
                    }
                }
            }
            return list;
        }
    }
}