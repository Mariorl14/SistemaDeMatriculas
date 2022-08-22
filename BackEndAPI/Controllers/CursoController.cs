using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : Controller
    {
        private ICursoDAL cursoDAL;

        CursoModel Convertir(Curso curso)
        {
            return new CursoModel
            {
                ID_CURSO = curso.IdCurso,
                NOMBRE_CURSO = curso.NombreCurso,
                CODIGO_CURSO = curso.CodigoCurso,
                PRECIO = curso.Precio,
                CREDITOS = curso.Creditos,
                DURACION = curso.Duracion,
                HORARIO = curso.Horario,
                NATURALEZA_CURSO = curso.NaturalezaCurso,
                ID_PLAN_ESTUDIO_FK = curso.IdPlanEstudioFk
            };

        }
        Curso Convertir(CursoModel curso)
        {

            return new Curso
            {
                IdCurso = curso.ID_CURSO,
                NombreCurso = curso.NOMBRE_CURSO,
                CodigoCurso = curso.CODIGO_CURSO,
                Precio = curso.PRECIO,
                Creditos = curso.CREDITOS,
                Duracion = curso.DURACION,
                Horario = curso.HORARIO,
                NaturalezaCurso = curso.NATURALEZA_CURSO,
                IdPlanEstudioFk = curso.ID_PLAN_ESTUDIO_FK
            };

        }

        public CursoController()
        {

            cursoDAL = new CursoDALImpl();

        }

        // GET: api/<CursoController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Curso> Cursos = cursoDAL.GetAll().ToList();
            List<CursoModel> result = new List<CursoModel>();

            foreach (Curso Curso in Cursos)
            {
                result.Add(Convertir(Curso));
            }

            return new JsonResult(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Curso curso = cursoDAL.Get(id);

            return new JsonResult(Convertir(curso));
        }

        // GET api/<CursoController>/Plan/idplan
        [HttpGet("Plan/{IdPlan}")]
        public JsonResult GetByPlan(int IdPlan)
        {
            List<Curso> Cursos = cursoDAL.GetByPlan(IdPlan).ToList();
            List<CursoModel> result = new List<CursoModel>();

            foreach (Curso Curso in Cursos)
            {
                result.Add(Convertir(Curso));
            }

            return new JsonResult(result);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] CursoModel curso)
        {
            cursoDAL.Add(Convertir(curso));

            return new JsonResult(Convertir(curso));
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] CursoModel curso)
        {
            cursoDAL.Update(Convertir(curso));

            return new JsonResult(Convertir(curso));
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Curso curso = new Curso
            {
                IdCurso = id
            };
            bool result = cursoDAL.Remove(curso);

            return new JsonResult(result);
        }
    }
}
