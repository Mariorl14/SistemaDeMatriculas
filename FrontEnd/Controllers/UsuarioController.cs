using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioDAL usuarioDAL;
        ITipoUsuarioDAL TipoUsuarioDAL;

        private UsuarioViewModel Convertir(Usuario usuario)
        {
            return new UsuarioViewModel
            {
                IdUsuario = usuario.IdUsuario,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Contrasena = usuario.Contrasena,    
                ConfirmarContrasena = usuario.ConfirmarContrasena,
                IdTipoUsuarioFk = usuario.IdTipoUsuarioFk
            };
        }

        #region Lista
        public IActionResult Index()
        {


            List<Usuario> lista;
            usuarioDAL = new UsuarioDALImpl();

            lista = usuarioDAL.GetAll().ToList();
            List<UsuarioViewModel> usuarios = new List<UsuarioViewModel>();

            foreach (Usuario usuario in lista)
            {
                usuarios.Add(Convertir(usuario));
            }


            return View(usuarios);
        }

        #endregion

        #region Agregar
        public IActionResult Create()
        {

            UsuarioViewModel usuario = new UsuarioViewModel();
            TipoUsuarioDAL = new TipoUsuarioDALImpl();

            usuario.TipoUsuarios = TipoUsuarioDAL.GetAll();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();
            usuarioDAL.Add(usuario);

            return RedirectToAction("Index");



        }

        #endregion

        #region Detalles

        public IActionResult Details(int id)
        {
            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuario = Convertir(usuarioDAL.Get(id));

            TipoUsuarioDAL = new TipoUsuarioDALImpl();
            usuario.tipo = TipoUsuarioDAL.Get((int)usuario.IdTipoUsuarioFk);


            return View(usuario);
        }
        #endregion


        #region  Editar


        public IActionResult Edit(int id)
        {
            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuario = Convertir(usuarioDAL.Get(id));

            TipoUsuarioDAL = new TipoUsuarioDALImpl();

            usuario.TipoUsuarios = TipoUsuarioDAL.GetAll();

            return View(usuario);
        }
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();

            usuarioDAL.Update(usuario);
            return RedirectToAction("Index");
        }

        #endregion


        #region Eliminar
        public IActionResult Delete(int id)
        {
            usuarioDAL = new UsuarioDALImpl();
            UsuarioViewModel usuario = Convertir(usuarioDAL.Get(id));
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Delete(Usuario usuario)
        {
            usuarioDAL = new UsuarioDALImpl();

            usuarioDAL.Remove(usuario);
            return RedirectToAction("Index");
        }

        #endregion

    }
}
