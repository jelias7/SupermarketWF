using Entidades;
using System;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Inventarios> Inventario { get; set; }
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Proveedores> Proveedor { get; set; }
        public DbSet<Secciones> Seccion { get; set; }
        public DbSet<Ventas> Venta { get; set; }
        public DbSet<VentasDetalle> Detalle { get; set; }
        public Contexto() : base("ConStr") { }
    }
}
