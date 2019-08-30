using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public string Cliente { get; set; }
        public string Modo { get; set; }
        public decimal Itbis { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<VentasDetalle> Detalle { get; set; }
        public Ventas()
        {
            VentaId = 0;
            UsuarioId = 0;
            Cliente = string.Empty;
            Modo = string.Empty;
            Itbis = 0;
            Subtotal = 0;
            Total = 0;
            Fecha = DateTime.Now;
            Detalle = new List<VentasDetalle>();
        }
    }
}
