using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Curso
    {
        public Curso()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int IdCurso { get; set; }
        public string NombreCurso { get; set; } = null!;
        public string CodigoCurso { get; set; } = null!;
        public double Precio { get; set; }
        public int Creditos { get; set; }
        public string Duracion { get; set; } = null!;
        public string Horario { get; set; } = null!;
        public string? NaturalezaCurso { get; set; }
        public int IdPlanEstudioFk { get; set; }

        public virtual PlanEstudio IdPlanEstudioFkNavigation { get; set; } = null!;
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
