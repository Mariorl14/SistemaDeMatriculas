using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioDAL tipoUusarioDAL;

        TipoUsuarioModel Convertir(TipoUsuario tipoUsuario)
        {

            return new TipoUsuarioModel
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                Descripcion = tipoUsuario.Descripcion
            };

        }

        TipoUsuario Convertir(TipoUsuarioModel tipoUsuario)
        {

            return new TipoUsuario
            {
                IdTipoUsuario = tipoUsuario.IdTipoUsuario,
                Descripcion = tipoUsuario.Descripcion
            };

        }


        public TipoUsuarioController()
        {

            tipoUusarioDAL = new TipoUsuarioDALImpl();

        }


        // GET: api/<TipoUsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<TipoUsuario> tipoUsuarios = tipoUusarioDAL.GetAll().ToList();
            List<TipoUsuarioModel> result = new List<TipoUsuarioModel>();
            foreach (TipoUsuario tipoUsuario in tipoUsuarios)
            {
                result.Add(Convertir(tipoUsuario));
            }
            return new JsonResult(result);
        }

        // GET api/<TipoUsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TipoUsuario tipoUsuario = tipoUusarioDAL.Get(id);

            return new JsonResult(Convertir(tipoUsuario));
        }

        // POST api/<TipoUsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] TipoUsuarioModel tipoUsuario)
        {
            tipoUusarioDAL.Add(Convertir(tipoUsuario));

            return new JsonResult(Convertir(tipoUsuario));
        }

        // PUT api/<TipoUsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TipoUsuarioModel tipoUsuario)
        {
            tipoUusarioDAL.Update(Convertir(tipoUsuario));

            return new JsonResult(Convertir(tipoUsuario));
        }

        // DELETE api/<TipoUsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            TipoUsuario tipoUsuario = new TipoUsuario
            {
                IdTipoUsuario = id
            };
            bool result = tipoUusarioDAL.Remove(tipoUsuario);

            return new JsonResult(result);
        }
    }
}
