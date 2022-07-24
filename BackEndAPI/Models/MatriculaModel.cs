using BackEnd.Entities;
using MatriculasAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class MatriculaModel
    {

        [Key]
        [Display(Name = "Id Matricula")]
        public int IdMatricula { get; set; }

        [Display(Name = "Fecha de Matricula")]
        public DateTime FechaMatricula { get; set; } = new DateTime()!;

        [Display(Name = "Id Estudiante")]
        public int IdEstudianteFk { get; set; }

        [Display(Name = "Carrera")]
        public int IdPlanEstudioFk { get; set; }

        [Display(Name = "Curso")]
        public int IdCursoFk { get; set; }
    }
}
