using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class AccesoController : Controller
    {

        


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            UsuarioDALImpl usuarioDAL = new UsuarioDALImpl();

            var usuarios = usuarioDAL.ValidarUsuario(usuario.Email, usuario.Contrasena);

            if(usuarios != null )
            {
                var claims = new List<Claim>
                {
                    new Claim("Correo", usuarios.Email),
                    new Claim(ClaimTypes.Role, usuarios.Rol)
                    
                };
                

                var clamsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(clamsIdentity));


                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

           
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }

    }
}
