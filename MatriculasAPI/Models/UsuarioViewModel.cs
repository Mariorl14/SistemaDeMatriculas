
using System.ComponentModel.DataAnnotations;
namespace MatriculasAPI.Models
{
    public class UsuarioViewModel
    {

        [Display(Name = "Id del Usuario")]
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

        [Display(Name = "Rol")]
        public string Rol { get; set; }

        public IEnumerable<TipoUsuarioViewModel> TipoUsuarios { get; set; }
        public TipoUsuarioViewModel tipo { get; set; }
    }
}

