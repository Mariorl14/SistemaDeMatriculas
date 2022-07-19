using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
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
                Rol = usuario.Rol,
                IdTipoUsuarioFk = usuario.IdTipoUsuarioFk,
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
                Rol = usuario.Rol,
                IdTipoUsuarioFk = usuario.IdTipoUsuarioFk,

            };

        }


        public UsuarioController()
        {

            usuarioDAL = new UsuarioDALImpl();

        }


        // GET: api/<UsuarioController>
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

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Usuario usuario = usuarioDAL.Get(id);

            return new JsonResult(Convertir(usuario));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel usuario)
        {
            usuarioDAL.Add(Convertir(usuario));

            return new JsonResult(Convertir(usuario));
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] UsuarioModel usuario)
        {
            usuarioDAL.Update(Convertir(usuario));

            return new JsonResult(Convertir(usuario));
        }

        // DELETE api/<UsuarioController>/5
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
