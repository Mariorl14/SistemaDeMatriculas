using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        [Display(Name="Id del Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Correo")]
        public string Email { get; set; } = null!;
        
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; } = null!;
        
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        public bool ConfirmarContrasena { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public int IdTipoUsuarioFk { get; set; }

        public IEnumerable<TipoUsuario> TipoUsuarios { get; set; }
        public TipoUsuario tipo { get; set; }
    }
}
