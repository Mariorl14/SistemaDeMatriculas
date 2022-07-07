using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles ="ADMIN, ESTU")]
    public class CursoController : Controller
    {
        ICursoDAL cursoDAL;
        IPlanDeEstudioDAL PlanDeEstudioDAL;

        private CursoViewModel Convertir(Curso curso)
        {
            return new CursoViewModel
            {
                IdCurso = curso.IdCurso,
                NombreCurso = curso.NombreCurso,
                CodigoCurso = curso.CodigoCurso,
                Precio = curso.Precio,
                Creditos = curso.Creditos,
                Duracion = curso.Duracion,
                Horario = curso.Horario,
                NaturalezaCurso = curso.NaturalezaCurso,
                IdPlanEstudioFk = curso.IdPlanEstudioFk
            };
        }

        #region Lista
        public IActionResult Index()
        {
            

            List<Curso> lista;
            cursoDAL = new CursoDALImpl();
            lista = cursoDAL.GetAll().ToList();
            List<CursoViewModel> cursos = new List<CursoViewModel>();

            foreach (Curso curso in lista)
            {
                cursos.Add(Convertir(curso));
            }   


            return View(cursos);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            CursoViewModel curso = new CursoViewModel();
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();

            curso.Planes = PlanDeEstudioDAL.GetAll();

            return View(curso);
        }

        [HttpPost]
        public IActionResult Create(Curso curso)
        {
            cursoDAL = new CursoDALImpl();
            cursoDAL.Add(curso);

            return RedirectToAction("Index");



        }

        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            cursoDAL = new CursoDALImpl();
            CursoViewModel curso = Convertir(cursoDAL.Get(id));

            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            curso.Plan = PlanDeEstudioDAL.Get((int)curso.IdPlanEstudioFk);


            return View(curso);
        }
        #endregion


        #region  Editar


        public IActionResult Edit(int id)
        {
            cursoDAL = new CursoDALImpl();
            CursoViewModel curso = Convertir(cursoDAL.Get(id));

            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();

            curso.Planes = PlanDeEstudioDAL.GetAll();

            return View(curso);
        }
        [HttpPost]
        public IActionResult Edit(Curso curso)
        {
            cursoDAL = new CursoDALImpl();

            cursoDAL.Update(curso);
            return RedirectToAction("Index");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(int id)
        {
            cursoDAL = new CursoDALImpl();
            CursoViewModel curso = Convertir(cursoDAL.Get(id));
            return View(curso);
        }
        [HttpPost]
        public IActionResult Delete(Curso curso)
        {
            cursoDAL = new CursoDALImpl();

            cursoDAL.Remove(curso);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
