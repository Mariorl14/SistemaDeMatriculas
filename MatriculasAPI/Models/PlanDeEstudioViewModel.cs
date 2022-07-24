using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace MatriculasAPI.Models
{
    public class PlanDeEstudioViewModel
    {
        

        [Key]
        [Display(Name = "Número del plan de estudios")]
        public int IdPlanEstudio { get; set; }

        [Display(Name = "Nombre de la Carrera")]
        public string NombrePlanEstduio { get; set; } = null!;

    }
}
