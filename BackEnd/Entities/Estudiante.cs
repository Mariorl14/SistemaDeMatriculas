using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = null!;
        public int IdUsuarioFk { get; set; }
        public int IdPlanEstudioFk { get; set; }
        public int IdTipoUsuarioFk { get; set; }

        public virtual PlanEstudio IdPlanEstudioFkNavigation { get; set; } = null!;
        public virtual TipoUsuario IdTipoUsuarioFkNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioFkNavigation { get; set; } = null!;
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
