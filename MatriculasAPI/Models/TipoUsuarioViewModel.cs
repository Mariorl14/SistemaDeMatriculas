using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace MatriculasAPI.Models
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
