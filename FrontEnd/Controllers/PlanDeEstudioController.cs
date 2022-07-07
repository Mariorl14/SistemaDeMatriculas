using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "ADMIN, ESTU")]
    public class PlanDeEstudioController : Controller
    {
        IPlanDeEstudioDAL PlanDeEstudioDAL;


        private PlanDeEstudioViewModel Convertir(PlanEstudio planEstudio)
        {
            return new PlanDeEstudioViewModel
            {
                IdPlanEstudio = planEstudio.IdPlanEstudio,
                NombrePlanEstduio = planEstudio.NombrePlanEstduio
            };
        }

        #region Lista
        public IActionResult Index()
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();

            List<PlanEstudio> lista;
            lista = PlanDeEstudioDAL.GetAll().ToList();
            List<PlanDeEstudioViewModel> planDeEstudios = new List<PlanDeEstudioViewModel>();

            foreach (PlanEstudio planEstudio in lista)
            {
                planDeEstudios.Add(Convertir(planEstudio));
            }   


            return View(planDeEstudios);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(PlanEstudio planEstudio)
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            PlanDeEstudioDAL.Add(planEstudio);

            return RedirectToAction("Index");



        }

        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            PlanEstudio planEstudio = PlanDeEstudioDAL.Get(id);

            return View(Convertir(planEstudio));
        }
        #endregion


        #region  Editar


        public IActionResult Edit(int id)
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            PlanEstudio planEstudio = PlanDeEstudioDAL.Get(id);
            return View(Convertir(planEstudio));
        }
        [HttpPost]
        public IActionResult Edit(PlanEstudio planEstudio)
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();

            PlanDeEstudioDAL.Update(planEstudio);
            return RedirectToAction("Index");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(int id)
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            PlanEstudio planEstudio = PlanDeEstudioDAL.Get(id);
            return View(Convertir(planEstudio));
        }
        [HttpPost]
        public IActionResult Delete(PlanEstudio planEstudio)
        {
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();

            PlanDeEstudioDAL.Remove(planEstudio);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
