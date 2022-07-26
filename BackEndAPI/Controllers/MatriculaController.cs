using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private IMatriculaDAL matriculaDAL;

        MatriculaModel Convertir(Matricula matricula) {

                return new MatriculaModel
            {

                IdMatricula = matricula.IdMatricula,
                FechaMatricula = matricula.FechaMatricula,
                IdEstudianteFk = matricula.IdEstudianteFk,
                IdPlanEstudioFk = matricula.IdPlanEstudioFk,
                IdCursoFk = matricula.IdCursoFk,

            };
        }

        Matricula Convertir(MatriculaModel matricula) {

            return new Matricula
            {
                IdMatricula = matricula.IdMatricula,
                FechaMatricula = matricula.FechaMatricula,
                IdEstudianteFk = matricula.IdEstudianteFk,
                IdPlanEstudioFk = matricula.IdPlanEstudioFk,
                IdCursoFk = matricula.IdCursoFk,
            };
        }

        public MatriculaController() {

            matriculaDAL = new MatriculaDALImpl();
        }

        [HttpGet]
        public JsonResult Get()
        {
            List<Matricula> matricula = matriculaDAL.GetAll().ToList();
            List<MatriculaModel> result = new List<MatriculaModel>();
            foreach (Matricula  matriculas in matricula)
            {
                result.Add(Convertir(matriculas));
            }
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Matricula matricula = matriculaDAL.Get(id);

            return new JsonResult(Convertir(matricula));
        }

        [HttpPost]
        public JsonResult Post([FromBody] MatriculaModel matricula)
        {
            matriculaDAL.Add(Convertir(matricula));

            return new JsonResult(Convertir(matricula));
        }

        [HttpPut]
        public JsonResult Put([FromBody] MatriculaModel matricula)
        {
            matriculaDAL.Update(Convertir(matricula));


            return new JsonResult(Convertir(matricula));
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Matricula matricula = new Matricula
            {
                IdMatricula = id
            };
            bool result = matriculaDAL.Remove(matricula);

            return new JsonResult(result);
        }
    }
}
