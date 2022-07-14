using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class PlanEstudioModel
    {
        [Key]
        [Display(Name = "Id del plan de estudios")]
        public int IdPlanEstudio { get; set; }

        [Display(Name = "Nombre de la Carrera")]
        public string NombrePlanEstduio { get; set; } = null!;

    }
}
