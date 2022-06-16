using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CursoViewModel
    {
        

        [Key]
        [Display(Name = "Id del Curso")]
        public int IdCurso { get; set; }

        [Display(Name = "Nombre del Curso")]
        public string NombreCurso { get; set; } = null!;

        [Display(Name = "Codigo del Curso")]
        public string CodigoCurso { get; set; } = null!;

        [Display(Name = "Precio del Curso")]
        public double Precio { get; set; }

        [Display(Name = "Creditos del Curso")]
        public int Creditos { get; set; }

        [Display(Name = "Duracion del Curso")]
        public string Duracion { get; set; } = null!;

        [Display(Name = "Horario del Curso")]
        public string Horario { get; set; } = null!;

        [Display(Name = "Naturaleza del Curso")]
        public string? NaturalezaCurso { get; set; }

        [Display(Name = "Carrera")]
        public int IdPlanEstudioFk { get; set; }

        public IEnumerable<PlanEstudio> Planes { get; set; }
        public PlanEstudio Plan { get; set; }

    }
}
