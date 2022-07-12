using System;
using System.Collections.Generic;

namespace BackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int Telefono { get; set; }
        public bool ConfirmarContrasena { get; set; }
        public int IdTipoUsuarioFk { get; set; }

        public string Rol { get; set; }

        public virtual TipoUsuario IdTipoUsuarioFkNavigation { get; set; } = null!;
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
