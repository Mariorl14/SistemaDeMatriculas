using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TipoUsuarioViewModel
    {
        [Key]
        [Display(Name = "Id del tipo de usuario")]
        public int IdTipoUsuario { get; set; }

        [Display(Name = "Tipo de usuario")]
        public string Descripcion { get; set; } = null!;
    }
}
