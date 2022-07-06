using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class EstudianteViewModel
    {

        [Key]
        [Display(Name = "Id Estudiante")]
        public int IdEstudiante { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; } = null!;

        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; } = null!;

        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; } = new DateTime()!;

        [Display(Name = "Género")]
        public string Genero { get; set; } = null!;

        [Display(Name = "Carrera")]
        public int IdPlanEstudioFk { get; set; }

        [Display(Name = "Id Usuario")]
        public int IdUsuarioFk { get; set; }

        [Display(Name = "Tipo Usuario")]
        public int IdTipoUsuarioFk { get; set; }

        public IEnumerable<PlanEstudio> Planes { get; set; }
        public IEnumerable<TipoUsuario> TipoUsuarios { get; set; }
        public PlanEstudio Plan { get; set; }
        public Usuario Usuario { get; set; }

    }
}
