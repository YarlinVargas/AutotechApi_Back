using AutotechApi.Data;
using AutotechApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutotechApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        [HttpPost]
        public async Task InsertarUsuario([FromBody] UsuarioModel user)
        {
            var function = new UsuarioData();
            await function.InsertarUsuario(user);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> EditarUsuario(int id, [FromBody] UsuarioModel user)
        {
            var function = new UsuarioData();
            user.Id_user = id;
            await function.EditarUsuario(user);

            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var user = new UsuarioModel();
            user.Id_user = id;
            var function = new UsuarioData();
            await function.EliminarUsuario(user);

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> MostrarUsuario()
        {
            var function = new UsuarioData();
            var lista = await function.MostrarCliente();
            return lista;


        }
    }
}
