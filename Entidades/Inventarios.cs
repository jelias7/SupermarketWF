using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public Inventarios()
        {
            InventarioId = 0;
            Cantidad = 0;
            Fecha = DateTime.Now;
            UsuarioId = 0;
            ProductoId = 0;
        }

    }
}
