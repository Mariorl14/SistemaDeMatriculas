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
    public class UsuarioController : Controller
    {

        private List<TipoUsuarioViewModel> LlenarComboTipoUsuarios()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/TipoUsuario/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<Models.TipoUsuarioViewModel> tipos = JsonConvert.DeserializeObject<List<Models.TipoUsuarioViewModel>>(content);

            return tipos;
        }

        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/usuario/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<Models.UsuarioViewModel>>(content);


                ViewBag.Title = "Usuarios";
                return View(usuarios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: UsuarioController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;
            return View(usuarioViewModel);
        }



        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.TipoUsuarios = LlenarComboTipoUsuarios();
            return View(usuario);
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.UsuarioViewModel usuario, List<IFormFile> upload)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/usuario", usuario);
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;
            usuarioViewModel.TipoUsuarios = LlenarComboTipoUsuarios();
            return View(usuarioViewModel);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.UsuarioViewModel usuario, List<IFormFile> upload)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/usuario", usuario);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: UsuarioController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;
            usuarioViewModel.TipoUsuarios = LlenarComboTipoUsuarios();
            return View(usuarioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.UsuarioViewModel usuario)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/usuario/" + usuario.IdUsuario.ToString());
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
