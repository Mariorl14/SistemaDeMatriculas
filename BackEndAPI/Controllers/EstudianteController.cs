using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        private IEstudianteDAL estudianteDAL;
        private IPlanDeEstudioDAL planDAL;

        EstudianteModel Convertir(Estudiante estudiante)
        {

            return new EstudianteModel
            {
                IdEstudiante = estudiante.IdEstudiante,
                Nombre = estudiante.Nombre,
                PrimerApellido = estudiante.PrimerApellido,
                SegundoApellido = estudiante.SegundoApellido,
                FechaNacimiento = estudiante.FechaNacimiento,
                Genero = estudiante.Genero,
                IdPlanEstudioFk = estudiante.IdPlanEstudioFk,
                IdUsuarioFk = estudiante.IdUsuarioFk,
                IdTipoUsuarioFk = estudiante.IdTipoUsuarioFk
            };

        }

        Estudiante Convertir(EstudianteModel estudiante)
        {

            return new Estudiante
            {
                IdEstudiante = estudiante.IdEstudiante,
                Nombre = estudiante.Nombre,
                PrimerApellido = estudiante.PrimerApellido,
                SegundoApellido = estudiante.SegundoApellido,
                FechaNacimiento = estudiante.FechaNacimiento,
                Genero = estudiante.Genero,
                IdPlanEstudioFk = estudiante.IdPlanEstudioFk,
                IdUsuarioFk = estudiante.IdUsuarioFk,
                IdTipoUsuarioFk = estudiante.IdTipoUsuarioFk
            };

        }

        public EstudianteController()
        {

            estudianteDAL = new EstudianteDALImpl();

        }


        // GET: api/<TipoUsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Estudiante> estudiantes = estudianteDAL.GetAll().ToList();
            List<EstudianteModel> result = new List<EstudianteModel>();
            foreach (Estudiante estudiante in estudiantes)
            {
                result.Add(Convertir(estudiante));
            }
            return new JsonResult(result);
        }

        // GET api/<TipoUsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Estudiante estudiante = estudianteDAL.Get(id);

            return new JsonResult(Convertir(estudiante));
        }

        // POST api/<TipoUsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] EstudianteModel estudiante)
        {
            estudianteDAL.Add(Convertir(estudiante));
            estudiante.Planes = planDAL.GetAll();

            return new JsonResult(Convertir(estudiante));
        }

        // PUT api/<TipoUsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] EstudianteModel estudiante)
        {
            estudianteDAL.Update(Convertir(estudiante));



            return new JsonResult(Convertir(estudiante));
        }

        // DELETE api/<TipoUsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Estudiante estudiante = new Estudiante
            {
                IdEstudiante = id
            };
            bool result = estudianteDAL.Remove(estudiante);

            return new JsonResult(result);
        }
    }
}