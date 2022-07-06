using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class MatriculaController : Controller
    {
        IMatriculaDAL matriculaDAL;
        IPlanDeEstudioDAL PlanDeEstudioDAL;
        ICursoDAL cursoDAL;
        IEstudianteDAL estudianteDAL;

        private MatriculaViewModel Convertir(Matricula matricula)
        {
            return new MatriculaViewModel
            {
                IdMatricula = matricula.IdMatricula,
                FechaMatricula = matricula.FechaMatricula,
                IdEstudianteFk = matricula.IdEstudianteFk,
                IdPlanEstudioFk = matricula.IdPlanEstudioFk,
                IdCursoFk = matricula.IdCursoFk
            };
        }

        #region Lista
        public IActionResult Index()
        {
            List<Matricula> lista;
            matriculaDAL = new MatriculaDALImpl();
            lista = matriculaDAL.GetAll().ToList();
            List<MatriculaViewModel> matriculas = new List<MatriculaViewModel>();
            foreach (Matricula matricula in lista)
            {
                matriculas.Add(Convertir(matricula));
            }


            return View(matriculas);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {
            MatriculaViewModel matricula = new MatriculaViewModel();
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            estudianteDAL = new EstudianteDALImpl();
            cursoDAL = new CursoDALImpl();

            matricula.Planes = PlanDeEstudioDAL.GetAll();
            matricula.Estudiantes = estudianteDAL.GetAll();
            matricula.Cursos = cursoDAL.GetAll();

            return View(matricula);
        }

        [HttpPost]
        public IActionResult Create(Matricula matricula)
        {
            matriculaDAL = new MatriculaDALImpl();
            matriculaDAL.Add(matricula);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            matriculaDAL = new MatriculaDALImpl();
            MatriculaViewModel matricula = Convertir(matriculaDAL.Get(id));

            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            estudianteDAL = new EstudianteDALImpl();
            cursoDAL = new CursoDALImpl();

            

            matricula.Plan = PlanDeEstudioDAL.Get((int)matricula.IdPlanEstudioFk);
            matricula.Estudiante = estudianteDAL.Get((int)matricula.IdEstudianteFk);
            matricula.Curso = cursoDAL.Get((int)matricula.IdCursoFk);

            return View(matricula);
        }
        #endregion


        #region  Editar


        public IActionResult Edit(int id)
        {

            matriculaDAL = new MatriculaDALImpl();
            MatriculaViewModel matricula = Convertir(matriculaDAL.Get(id));

            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            estudianteDAL = new EstudianteDALImpl();
            cursoDAL = new CursoDALImpl();

            matricula.Planes = PlanDeEstudioDAL.GetAll();
            matricula.Estudiantes = estudianteDAL.GetAll();
            matricula.Cursos = cursoDAL.GetAll();


            return View(matricula);
        }
        [HttpPost]
        public IActionResult Edit(Matricula matricula)
        {
            matriculaDAL = new MatriculaDALImpl();

            matriculaDAL.Update(matricula);
            return RedirectToAction("Index");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(int id)
        {
            matriculaDAL = new MatriculaDALImpl();
            MatriculaViewModel matricula = Convertir(matriculaDAL.Get(id));
            return View(matricula);
        }
        [HttpPost]
        public IActionResult Delete(Matricula matricula)
        {
            matriculaDAL = new MatriculaDALImpl();

            matriculaDAL.Remove(matricula);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
