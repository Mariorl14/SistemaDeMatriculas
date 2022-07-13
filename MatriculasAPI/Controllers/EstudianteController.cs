using MatriculasAPI.Helpers;
using MatriculasAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatriculasAPI.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/estudiante/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.EstudianteViewModel> estudiantes = JsonConvert.DeserializeObject<List<Models.EstudianteViewModel>>(content);


                ViewBag.Title = "Estudiantes";
                return View(estudiantes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: CategoryController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/estudiante/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.EstudianteViewModel estudianteViewModel = response.Content.ReadAsAsync<Models.EstudianteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(estudianteViewModel);
        }



        // GET: CategoryController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.EstudianteViewModel estudiante, List<IFormFile> upload)
        {
            try
            {
              
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/estudiante", estudiante);
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/estudiante/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.EstudianteViewModel estudianteViewModel = response.Content.ReadAsAsync<Models.EstudianteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(estudianteViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.EstudianteViewModel estudiante, List<IFormFile> upload)
        {
         
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/estudiante", estudiante);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/estudiante/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.EstudianteViewModel estudianteViewModel = response.Content.ReadAsAsync<Models.EstudianteViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(estudianteViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.EstudianteViewModel estudiante)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/estudiante/" + estudiante.IdEstudiante.ToString());
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
