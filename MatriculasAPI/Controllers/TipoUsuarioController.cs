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

namespace MatriculasAPI.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tipousuario/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.TipoUsuarioViewModel> tipoUsuarios = JsonConvert.DeserializeObject<List<Models.TipoUsuarioViewModel>>(content);


                ViewBag.Title = "Tipos de usuarios";
                return View(tipoUsuarios);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/tipousuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.TipoUsuarioViewModel tipoUsuarioViewModel = response.Content.ReadAsAsync<Models.TipoUsuarioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(tipoUsuarioViewModel);
        }



        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.TipoUsuarioViewModel tipoUsuario, List<IFormFile> upload)
        {
            try
            {
              
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tipousuario", tipoUsuario);
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
            HttpResponseMessage response = serviceObj.GetResponse("api/tipousuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.TipoUsuarioViewModel tipoUsuarioViewModel = response.Content.ReadAsAsync<Models.TipoUsuarioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(tipoUsuarioViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.TipoUsuarioViewModel tipoUsuario, List<IFormFile> upload)
        {
         
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/tipousuario", tipoUsuario);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tipousuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.TipoUsuarioViewModel tipoUsuarioViewModel = response.Content.ReadAsAsync<Models.TipoUsuarioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(tipoUsuarioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.TipoUsuarioViewModel tipoUsuario)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/tipousuario/" + tipoUsuario.IdTipoUsuario.ToString());
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
