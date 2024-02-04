using AutotechApi.Connection;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AutotechApi.Data
{
    public class VehiculoData
    {
        //traemos la conexion a la bd
        conexionbd cn = new conexionbd();

        //Metodo para insertar clientes
        public async Task InsertarVehiculo(VehiculoModel vehicle)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("insertarInventario", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("placa", vehicle.placa);
                    store.Parameters.AddWithValue("idClient", vehicle.idClient);
                    store.Parameters.AddWithValue("modelo", vehicle.modelo);
                    store.Parameters.AddWithValue("mark", vehicle.mark);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para editar vehiculos
        public async Task EditarVehiculos(VehiculoModel vehicle)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("editarVehiculo", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("placa", vehicle.placa);
                    store.Parameters.AddWithValue("idClient", vehicle.idClient);
                    store.Parameters.AddWithValue("modelo", vehicle.modelo);
                    store.Parameters.AddWithValue("mark", vehicle.mark);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para eliminar vehiculo
        public async Task EliminarVehiculo(VehiculoModel vehicle)
        {
            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("eliminarVehiculo", sql))
                {
                    store.CommandType = CommandType.StoredProcedure;
                    store.Parameters.AddWithValue("id_vehicle", vehicle.Id_vehicle);

                    await sql.OpenAsync();
                    await store.ExecuteNonQueryAsync();
                }
            }
        }
        //Metodo para mostrar lista de vehiculos
        public async Task<ActionResult<List<VehiculoModel>>> MostrarVehiculo()
        {
            var list = new List<VehiculoModel>();

            using (var sql = new SqlConnection(cn.cadenaSql()))
            {
                using (var store = new SqlCommand("mostrarVehiculo", sql))
                {
                    await sql.OpenAsync();
                    store.CommandType = CommandType.StoredProcedure;
                    using (var item = await store.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mvehicle = new VehiculoModel();
                            mvehicle.Id_vehicle = (int)item["id_vehicle"];
                            mvehicle.placa = (string)item["placa"];
                            mvehicle.idClient = (int)item["idClient"];
                            mvehicle.modelo = (string)item["modelo"];
                            mvehicle.mark = (string)item["mark"];

                            list.Add(mvehicle);
                        }
                    }
                }
            }
            return list;
        }
    }
}
