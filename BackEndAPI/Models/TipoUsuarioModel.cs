using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class TipoUsuarioModel
    {
        public int IdTipoUsuario { get; set; }

        [Required]
        public string Descripcion { get; set; } = null!;

    }
}
