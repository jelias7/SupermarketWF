using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Usuario = string.Empty;
            Clave = string.Empty;
            Nombres = string.Empty;
            Email = string.Empty;
            FechaCreacion = DateTime.Now;
        }
    }
}
