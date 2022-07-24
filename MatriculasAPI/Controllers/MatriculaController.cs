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
            HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.EstudianteViewModel> estudiante = JsonConvert.DeserializeObject<List<Models.EstudianteViewModel>>(content);

            return estudiante;
        }

        private List<PlanEstudioViewModel> LlenarComboPlanEstudio()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.PlanEstudioViewModel> planes = JsonConvert.DeserializeObject<List<Models.PlanEstudioViewModel>>(content);

            return planes;
        }
       

        private List<CursoViewModel> LlenarComboCursos()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.CursoViewModel> tipos = JsonConvert.DeserializeObject<List<Models.CursoViewModel>>(content);

            return tipos;
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

        #region Agregar

        public ActionResult Create()
        {
            MatriculaViewModel matricula = new MatriculaViewModel();

            matricula.IdEstudiante = LlenarComboIdEstudiante();
            matricula.PlandeEstudiosM = (IEnumerable<PlanDeEstudioViewModel>)LlenarComboPlanEstudio();
            matricula.CursoMatricula = LlenarComboCursos();

            return View(matricula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.MatriculaViewModel matricula, List<IFormFile> upload)
        {
            try
            {

                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Matricula", matricula);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }


        #endregion


        #region Editar
       
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.MatriculaViewModel matriculaViewModel = response.Content.ReadAsAsync<Models.MatriculaViewModel>().Result;
       
            return View(matriculaViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Models.MatriculaViewModel matricula, List<IFormFile> upload)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Matricula", matricula);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }
        #endregion

        #region Eliminar

        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Matricula/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.MatriculaViewModel matriculaViewModel = response.Content.ReadAsAsync<Models.MatriculaViewModel>().Result;
           
            return View(matriculaViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.MatriculaViewModel matricula)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Matricula/" + matricula.IdMatricula.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

            if (Eliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        #endregion

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
