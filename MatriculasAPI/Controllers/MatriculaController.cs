using Microsoft.AspNetCore.Mvc;
using MatriculasAPI.Helpers;
using Newtonsoft.Json;
using MatriculasAPI.Models;

namespace MatriculasAPI.Controllers
{
    public class MatriculaController : Controller
    {

        #region ComboBox

        private List<EstudianteViewModel> LlenarComboIdEstudiante()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Estudiante/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.EstudianteViewModel> estudiante = JsonConvert.DeserializeObject<List<Models.EstudianteViewModel>>(content);

            return estudiante;
        }

        private List<PlanEstudioViewModel> LlenarComboPlanEstudio()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/PlanEstudio/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.PlanEstudioViewModel> planes = JsonConvert.DeserializeObject<List<Models.PlanEstudioViewModel>>(content);

            return planes;
        }
       

        private List<CursoViewModel> LlenarComboCursos()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Curso/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.CursoViewModel> cursos = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(content);

            return cursos;
        }

        private List<CursoViewModel> LlenarComboCursosPlan(int idPlan)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Curso/Plan/" + idPlan);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.CursoViewModel> cursos = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(content);

            return cursos;
        }

        #endregion
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.MatriculaViewModel> matricula = JsonConvert.DeserializeObject<List<Models.MatriculaViewModel>>(content);


                ViewBag.Title = "Matricula";
                return View(matricula);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult MisCursos()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/matricula/");
                HttpResponseMessage responseCurso = serviceObj.GetResponse("api/curso/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                var contentCurso = responseCurso.Content.ReadAsStringAsync().Result;

                List<Models.MatriculaViewModel> matriculas = JsonConvert.DeserializeObject<List<Models.MatriculaViewModel>>(content).Where(b => b.IdEstudianteFk.Equals(3)).ToList();
                List<Models.CursoViewModel> cursos = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(contentCurso);
                List<Models.MatriculaViewModel> matriculasResult = new List<Models.MatriculaViewModel>();

                foreach (var curso in matriculas)
                {

                    curso.nombrecurso = cursos.Where(b => b.ID_CURSO == curso.IdCursoFk)
                     .Select(x => x.NOMBRE_CURSO).FirstOrDefault();

                                      matriculasResult.Add(curso);
                }


                ViewBag.Title = "Matriculas";



                return View(matriculasResult);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Matricular()
        {
            int estudianteId = 3;
            int planEstudio = 1;

            MatriculaViewModel matricula = new MatriculaViewModel();
            matricula.CursoMatricula = LlenarComboCursosPlan(planEstudio);

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage responseEstudiante = serviceObj.GetResponse("api/Estudiante/" + estudianteId);
            HttpResponseMessage responsePlan = serviceObj.GetResponse("api/PlanEstudio/" + planEstudio);

            var contentEstudiante = responseEstudiante.Content.ReadAsStringAsync().Result;
            var contentPlan = responsePlan.Content.ReadAsStringAsync().Result;

            EstudianteViewModel estudiante = JsonConvert.DeserializeObject<EstudianteViewModel>(contentEstudiante);
            PlanEstudioViewModel plan = JsonConvert.DeserializeObject<PlanEstudioViewModel>(contentPlan);


            List<EstudianteViewModel> listaEstudiantes = new List<EstudianteViewModel>();
            listaEstudiantes.Add(estudiante);

            List<PlanEstudioViewModel> listaPlanes = new List<PlanEstudioViewModel>();
            listaPlanes.Add(plan);

            matricula.PlandeEstudiosM = listaPlanes;
            matricula.IdEstudiante = listaEstudiantes;
            

            return View(matricula);

        }

        // POST: MatriculaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatriculaViewModel matricula, List<IFormFile> upload)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/matricula", matricula);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("MisCursos");
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "MisCursos");
            }

            catch (Exception)
            {

                throw;
            }
        }



        public ActionResult Details(int id)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.MatriculaViewModel matriculaViewModel = response.Content.ReadAsAsync<Models.MatriculaViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(matriculaViewModel);
        }


    }
}
