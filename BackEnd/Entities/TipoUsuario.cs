using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Estudiantes = new HashSet<Estudiante>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
