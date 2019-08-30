using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VentaBLL
    {
        public static bool Guardar(Ventas venta)
        {
            bool paso = false;
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            Contexto db = new Contexto();
            try
            {
                if (db.Venta.Add(venta) != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        var producto = prod.Buscar(item.ProductoId);
                       producto.Cantidad -= item.Cantidad;
                        prod.Modificar(producto);
                    }
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();

            try
            {
                var venta = db.Venta.Find(id);
                foreach (var item in venta.Detalle)
                {
                    var producto = prod.Buscar(item.ProductoId);
                    producto.Cantidad += item.Cantidad;
                    prod.Modificar(producto);
                }
                db.Entry(venta).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Ventas> vent = new RepositorioBase<Ventas>();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            try
            {
                var venta = vent.Buscar(ventas.VentaId);


                if (ventas != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        db.Producto.Find(item.ProductoId).Cantidad += item.Cantidad;
                        if (!ventas.Detalle.ToList().Exists(v => v.VentaDetalleId == item.VentaDetalleId))
                        {

                           db.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in ventas.Detalle)
                    {
                        db.Producto.Find(item.ProductoId).Cantidad -= item.Cantidad;
                        var estado = item.VentaDetalleId > 0 ? EntityState.Modified : EntityState.Added;
                        db.Entry(item).State = estado;
                    }

                    db.Entry(ventas).State = EntityState.Modified;
                }

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                }
                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
