using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class TipoUsuarioController : Controller
    {
        ITipoUsuarioDAL tipoUsuarioDAL;


        private TipoUsuarioViewModel Convertir(TipoUsuario tipoUsuario)
        {
            return new TipoUsuarioViewModel
            {
                IdTipoUsuario= tipoUsuario.IdTipoUsuario,
                Descripcion = tipoUsuario.Descripcion
                
            };
        }

        #region Lista
        public IActionResult Index()
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();

            List<TipoUsuario> lista;
            lista = tipoUsuarioDAL.GetAll().ToList();
            List<TipoUsuarioViewModel> tipoUsuarios = new List<TipoUsuarioViewModel>();

            foreach (TipoUsuario tipoUsuario in lista)
            {
                tipoUsuarios.Add(Convertir(tipoUsuario));
            }


            return View(tipoUsuarios);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoUsuario tipoUsuario)
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();
            tipoUsuarioDAL.Add(tipoUsuario);

            return RedirectToAction("Index");



        }

        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();
            TipoUsuario tipoUsuario = tipoUsuarioDAL.Get(id);

            return View(Convertir(tipoUsuario));
        }
        #endregion


        #region  Editar


        public IActionResult Edit(int id)
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();
            TipoUsuario tipoUsuario = tipoUsuarioDAL.Get(id);
            return View(Convertir(tipoUsuario));
        }
        [HttpPost]
        public IActionResult Edit(TipoUsuario tipoUsuario)
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();

            tipoUsuarioDAL.Update(tipoUsuario);
            return RedirectToAction("Index");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(int id)
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();
            TipoUsuario tipoUsuario = tipoUsuarioDAL.Get(id);
            return View(Convertir(tipoUsuario));
        }
        [HttpPost]
        public IActionResult Delete(TipoUsuario tipoUsuario)
        {
            tipoUsuarioDAL = new TipoUsuarioDALImpl();

            tipoUsuarioDAL.Remove(tipoUsuario);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
