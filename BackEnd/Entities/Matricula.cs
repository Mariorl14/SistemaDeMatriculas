using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Matricula
    {
        public int IdMatricula { get; set; }
        public DateTime FechaMatricula { get; set; }
        public int IdEstudianteFk { get; set; }
        public int IdPlanEstudioFk { get; set; }
        public int IdCursoFk { get; set; }

        public virtual Curso IdCursoFkNavigation { get; set; } = null!;
        public virtual Estudiante IdEstudianteFkNavigation { get; set; } = null!;
        public virtual PlanEstudio IdPlanEstudioFkNavigation { get; set; } = null!;
    }
}
