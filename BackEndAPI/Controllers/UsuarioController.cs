using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioDAL usuarioDAL;

        UsuarioModel Convertir(Usuario usuario)
        {

            return new UsuarioModel
            {
                IdUsuario = usuario.IdUsuario,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Contrasena = usuario.Contrasena,
                ConfirmarContrasena = usuario.ConfirmarContrasena,
                Rol = usuario.Rol
            };

        }

        Usuario Convertir(UsuarioModel usuario)
        {

            return new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Contrasena = usuario.Contrasena,
                ConfirmarContrasena = usuario.ConfirmarContrasena,
                Rol = usuario.Rol
            };

        }


        public UsuarioController()
        {

            usuarioDAL = new UsuarioDALImpl();

        }


        // GET: api/<TipoUsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Usuario> usuarios = usuarioDAL.GetAll().ToList();
            List<UsuarioModel> result = new List<UsuarioModel>();
            foreach (Usuario usuario in usuarios)
            {
                result.Add(Convertir(usuario));
            }
            return new JsonResult(result);
        }

        // GET api/<TipoUsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Usuario usuario = usuarioDAL.Get(id);

            return new JsonResult(Convertir(usuario));
        }

        // POST api/<TipoUsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel usuario)
        {
            usuarioDAL.Add(Convertir(usuario));

            return new JsonResult(Convertir(usuario));
        }

        // PUT api/<TipoUsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] UsuarioModel usuario)
        {
            usuarioDAL.Update(Convertir(usuario));

            return new JsonResult(Convertir(usuario));
        }

        // DELETE api/<TipoUsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Usuario usuario = new Usuario
            {
                IdUsuario = id
            };
            bool result = usuarioDAL.Remove(usuario);

            return new JsonResult(result);
        }
    }
}
