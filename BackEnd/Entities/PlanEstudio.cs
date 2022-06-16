using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class PlanEstudio
    {
        public PlanEstudio()
        {
            Cursos = new HashSet<Curso>();
            Estudiantes = new HashSet<Estudiante>();
            Matriculas = new HashSet<Matricula>();
        }

        public int IdPlanEstudio { get; set; }
        public string NombrePlanEstduio { get; set; } = null!;

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
