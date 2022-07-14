using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanEstudioController : ControllerBase
    {

        private IPlanDeEstudioDAL planEstudioDAL;

        PlanEstudioModel Convertir(PlanEstudio planEstudio)
        {

            return new PlanEstudioModel
            {
                IdPlanEstudio = planEstudio.IdPlanEstudio,
                NombrePlanEstduio = planEstudio.NombrePlanEstduio
            };

        }

        PlanEstudio Convertir(PlanEstudioModel planEstudio)
        {

            return new PlanEstudio
            {
                IdPlanEstudio = planEstudio.IdPlanEstudio,
                NombrePlanEstduio = planEstudio.NombrePlanEstduio
            };

        }


        public PlanEstudioController()
        {

            planEstudioDAL = new PlanDeEstudioDALImpl();

        }


        // GET: api/<TipoUsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<PlanEstudio> planEstudios = planEstudioDAL.GetAll().ToList();
            List<PlanEstudioModel> result = new List<PlanEstudioModel>();
            foreach (PlanEstudio planEstudio in planEstudios)
            {
                result.Add(Convertir(planEstudio));
            }
            return new JsonResult(result);
        }

        // GET api/<TipoUsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            PlanEstudio planEstudio = planEstudioDAL.Get(id);

            return new JsonResult(Convertir(planEstudio));
        }

        // POST api/<TipoUsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] PlanEstudioModel planEstudio)
        {
            planEstudioDAL.Add(Convertir(planEstudio));

            return new JsonResult(Convertir(planEstudio));
        }

        // PUT api/<TipoUsuarioController>/5
        [HttpPut]
        public JsonResult Put([FromBody] PlanEstudioModel planEstudio)
        {
            planEstudioDAL.Update(Convertir(planEstudio));

            return new JsonResult(Convertir(planEstudio));
        }

        // DELETE api/<TipoUsuarioController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            PlanEstudio planEstudio = new PlanEstudio
            {
                IdPlanEstudio = id
            };
            bool result = planEstudioDAL.Remove(planEstudio);

            return new JsonResult(result);
        }
    }
}
