using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Clientes()
        {
            ClienteId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
