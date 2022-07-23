using System.ComponentModel.DataAnnotations;

namespace MatriculasAPI.Models
{
    public class CursoViewModel
    {
        [Display(Name = "Id del curso")]
        public int ID_CURSO { get; set; }

        [Display(Name = "Nombre del Curso")]
        public string NOMBRE_CURSO { get; set; } = null!;

        [Display(Name = "Código del Curso")]
        public string CODIGO_CURSO { get; set; } = null!;

        [Display(Name = "Precio")]
        public double PRECIO { get; set; }

        [Display(Name = "Créditos")]
        public int CREDITOS { get; set; }

        [Display(Name = "Duración")]
        public string DURACION { get; set; } = null!;

        [Display(Name = "Horario")]
        public string HORARIO { get; set; } = null!;

        [Display(Name = "Naturaleza del curso")]
        public string? NATURALEZA_CURSO { get; set; } = null!;

        [Display(Name = "Plan de estudio")]
        public int ID_PLAN_ESTUDIO_FK { get; set; }

        public IEnumerable<PlanEstudioViewModel> PlanesEstudio { get; set; }
        public PlanEstudioViewModel plan { get; set; }
    }
}
