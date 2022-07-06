using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class EstudianteController : Controller
    {
        IEstudianteDAL estudianteDAL;
        IPlanDeEstudioDAL PlanDeEstudioDAL;
        ITipoUsuarioDAL TipoUsuarioDAL;

        private EstudianteViewModel Convertir(Estudiante estudiante)
        {
            return new EstudianteViewModel
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

        #region Lista
        public IActionResult Index()
        {
            List<Estudiante> lista;
            estudianteDAL = new EstudianteDALImpl();
            lista = estudianteDAL.GetAll().ToList();
            List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

            foreach (Estudiante estudiante in lista)
            {
                estudiantes.Add(Convertir(estudiante));
            }


            return View(estudiantes);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {
            EstudianteViewModel estudiante = new EstudianteViewModel();
            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            TipoUsuarioDAL = new TipoUsuarioDALImpl();

            estudiante.Planes = PlanDeEstudioDAL.GetAll();
            estudiante.TipoUsuarios = TipoUsuarioDAL.GetAll();

            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            estudianteDAL = new EstudianteDALImpl();
            estudianteDAL.Add(estudiante);

            return RedirectToAction("Index");
        }

        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            estudianteDAL = new EstudianteDALImpl();
            EstudianteViewModel estudiante = Convertir(estudianteDAL.Get(id));

            //UsuarioDAL = new UsuarioDALImpl();
            //estudiante.Usuario = UsuarioDAL.Get((int)estudiante.IdUsuarioFk);

            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            estudiante.Plan = PlanDeEstudioDAL.Get((int)estudiante.IdPlanEstudioFk);

            return View(estudiante);
        }
        #endregion


        #region  Editar


        public IActionResult Edit(int id)
        {
            estudianteDAL = new EstudianteDALImpl();
            EstudianteViewModel estudiante = Convertir(estudianteDAL.Get(id));

            PlanDeEstudioDAL = new PlanDeEstudioDALImpl();
            TipoUsuarioDAL = new TipoUsuarioDALImpl();

            estudiante.Planes = PlanDeEstudioDAL.GetAll();
            estudiante.TipoUsuarios = TipoUsuarioDAL.GetAll();

            return View(estudiante);
        }
        [HttpPost]
        public IActionResult Edit(Estudiante estudiante)
        {
            estudianteDAL = new EstudianteDALImpl();

            estudianteDAL.Update(estudiante);
            return RedirectToAction("Index");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(int id)
        {
            estudianteDAL = new EstudianteDALImpl();
            EstudianteViewModel estudiante = Convertir(estudianteDAL.Get(id));
            return View(estudiante);
        }
        [HttpPost]
        public IActionResult Delete(Estudiante estudiante)
        {
            estudianteDAL = new EstudianteDALImpl();

            estudianteDAL.Remove(estudiante);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
