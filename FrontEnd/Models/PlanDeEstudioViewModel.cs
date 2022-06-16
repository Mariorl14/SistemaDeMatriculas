using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PlanDeEstudioViewModel
    {
        

        [Key]
        [Display(Name = "Id del plan de estudios")]
        public int IdPlanEstudio { get; set; }

        [Display(Name = "Nombre de la Carrera")]
        public string NombrePlanEstduio { get; set; } = null!;

    }
}
