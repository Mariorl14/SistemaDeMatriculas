using MatriculasAPI.Helpers;
using MatriculasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MatriculasAPI.Controllers
{
    public class CursoController : Controller
    {
        private List<PlanEstudioViewModel> LlenarComboPlanesEstudio()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<PlanEstudioViewModel> planes = JsonConvert.DeserializeObject<List<PlanEstudioViewModel>>(content);

            return planes;
        }

        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/curso/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<CursoViewModel> cursos = JsonConvert.DeserializeObject<List<CursoViewModel>>(content);

                ViewBag.Title = "Cursos";
                return View(cursos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            CursoViewModel curso = new CursoViewModel();
            curso.PlanesEstudio = LlenarComboPlanesEstudio();
            return View(curso);
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.CursoViewModel curso, List<IFormFile> upload)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/curso", curso);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/curso/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.CursoViewModel cursoViewModel = response.Content.ReadAsAsync<Models.CursoViewModel>().Result;
            return View(cursoViewModel);
        }

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/curso/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.CursoViewModel cursoViewModel = response.Content.ReadAsAsync<CursoViewModel>().Result;
            cursoViewModel.PlanesEstudio = LlenarComboPlanesEstudio();
            return View(cursoViewModel);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.CursoViewModel curso, List<IFormFile> upload)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/curso", curso);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CursoController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/curso/" + id.ToString());
            response.EnsureSuccessStatusCode();
            CursoViewModel cursoViewModel = response.Content.ReadAsAsync<CursoViewModel>().Result;
            cursoViewModel.PlanesEstudio = LlenarComboPlanesEstudio();
            return View(cursoViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.CursoViewModel curso)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/curso/" + curso.ID_CURSO.ToString());
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
    }
}
