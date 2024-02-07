using AutotechApi.Data;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutotechApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public async Task InsertarCliente([FromBody] ClienteModel client)
        {
            var function = new ClienteData();
            await function.InsertarCliente(client);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> EditarCliente(int id, [FromBody] ClienteModel client)
        {
            var function = new ClienteData();
            client.Id_cliente = id;
            await function.EditarCliente(client);

            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            var client = new ClienteModel();
            client.Id_cliente = id;
            var function = new ClienteData();
            await function.EliminarCliente(client);

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> MostrarClientes()
        {
            var function = new ClienteData();
            var lista = await function.MostrarCliente();
            return lista;


        }
    }
}
