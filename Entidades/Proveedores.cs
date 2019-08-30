using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        public string Nombres { get; set; }
        public string Contacto { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }

        public Proveedores()
        {
            ProveedorId = 0;
            Nombres = string.Empty;
            Contacto = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Fecha = DateTime.Now;
            UsuarioId = 0;
        }
    }
}

