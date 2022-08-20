using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace MatriculasAPI.Models
{
    public class MatriculaViewModel
    {
        [Key]
        [Display(Name = "Id Matricula")]
        public int IdMatricula { get; set; }

        [Display(Name = "Fecha de Matricula")]
        public DateTime FechaMatricula { get; set; } = new DateTime()!;

        [Display(Name = "Id Estudiante")]
        public int IdEstudianteFk { get; set; }
        public IEnumerable<Estudiante> Estudiantes { get; set; }
        public Estudiante Estudiante { get; set; }

        [Display(Name = "Carrera")]
        public int IdPlanEstudioFk { get; set; }

        [Display(Name = "Curso")]
        public int IdCursoFk { get; set; }
        public string nombrecurso { get; set; }

        public IEnumerable<Curso> Cursos { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<PlanEstudio> Planes { get; set; }
        public PlanEstudio Plan { get; set; }

        //ComboBox
        public IEnumerable<EstudianteViewModel> IdEstudiante { get; set; }
        public IEnumerable<PlanEstudioViewModel> PlandeEstudiosM { get; set; }
        public IEnumerable<CursoViewModel> CursoMatricula { get; set; }
    }
}
