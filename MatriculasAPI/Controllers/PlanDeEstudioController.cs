using MatriculasAPI.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Rotativa;
using Rotativa.AspNetCore;
using System.Net;
using BackEnd.Entities;

namespace MatriculasAPI.Controllers
{
    public class PlanDeEstudioController : Controller
    {

     
        // GET: CategoryController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.PlanEstudioViewModel> planestudio = JsonConvert.DeserializeObject<List<Models.PlanEstudioViewModel>>(content);


                ViewBag.Title = "Planes de Estudio";
                return View(planestudio);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PlanEstudioViewModel planestudioViewModel = response.Content.ReadAsAsync<Models.PlanEstudioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(planestudioViewModel);
        }



        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.PlanEstudioViewModel planestudio, List<IFormFile> upload)
        {
            try
            {
              
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/planestudio", planestudio);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PlanEstudioViewModel planestudioViewModel = response.Content.ReadAsAsync<Models.PlanEstudioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(planestudioViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.PlanEstudioViewModel planestudio, List<IFormFile> upload)
        {
         
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/planestudio", planestudio);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PlanEstudioViewModel planestudioViewModel = response.Content.ReadAsAsync<Models.PlanEstudioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(planestudioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.PlanEstudioViewModel planestudio)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/planestudio/" + planestudio.IdPlanEstudio.ToString());
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
