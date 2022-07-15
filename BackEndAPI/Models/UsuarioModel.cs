﻿using BackEnd.Entities;
using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class UsuarioModel
    {
        [Display(Name = "Id del Usuario")]
        public int IdUsuario { get; set; }

        [Display(Name = "Correo")]
        public string Email { get; set; } = null!;

        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; } = null!;

        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        public bool ConfirmarContrasena { get; set; }

        [Display(Name = "Tipo de Usuario")]
        public int IdTipoUsuarioFk { get; set; }

        [Display(Name = "Rol")]
        public string Rol { get; set; }

       
    }
}
