using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Secciones
    {
        [Key]
        public int SeccionId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Secciones()
        {
            SeccionId = 0;
            Nombre = string.Empty;
            Fecha = DateTime.Now;
            UsuarioId = 0;
        }
    }
}
