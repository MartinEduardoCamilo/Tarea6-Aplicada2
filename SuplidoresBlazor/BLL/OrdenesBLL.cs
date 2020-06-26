using Microsoft.EntityFrameworkCore;
using SuplidoresBlazor.DAL;
using SuplidoresBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuplidoresBlazor.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.ordenId))//si no existe insertamos
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        private static bool Insertar(Ordenes ordenes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                //Se suman las cantidades de productos existente al inventario del producto
                foreach (var item in ordenes.OrdenDetalles)
                {
                    var orden = contexto.Productos.Find(item.productoId);
                    if (orden != null)
                    {
                        orden.inventario += item.cantidad;
                    }
                }
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Ordenes ordenes)
        {
            bool paso = false;
            var Anterior = Buscar(ordenes.ordenId);
            Contexto contexto = new Contexto();

            try
            {
                //Aqui elimino el detalle y disminuyo el producto devuelto en el inventario
                foreach (var item in Anterior.OrdenDetalles)
                {
                    var producto = contexto.Productos.Find(item.productoId);
                    if (!ordenes.OrdenDetalles.Exists(d => d.ordenDetalleId == item.ordenDetalleId))
                    {
                        if (producto != null)
                        {
                            producto.inventario -= item.cantidad;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                //En esta parte se agregar nuevos datos al detalle
                foreach (var item in ordenes.OrdenDetalles)
                {
                    var producto = contexto.Productos.Find(item.productoId);
                    if (item.ordenDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (producto != null)
                        {
                            producto.inventario += item.cantidad;
                        }

                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }


                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            var Anterior = Buscar(id);
            Contexto contexto = new Contexto();

            try
            {
                if (Existe(id))
                {
                    //En esta sesion se disminuye las cantidades correspondientes a los producto
                    foreach (var item in Anterior.OrdenDetalles)
                    {
                        var producto = contexto.Productos.Find(item.productoId);
                        if (producto != null)
                        {
                            producto.inventario -= item.cantidad;
                        }
                    }

                    //Aqui se elimina la entidad
                    var orden = contexto.Ordenes.Find(id);
                    if (orden != null)
                    {
                        contexto.Ordenes.Remove(orden);
                        paso = contexto.SaveChanges() > 0;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes ordenes;

            try
            {
                ordenes = contexto.Ordenes.
                    Where(o => o.ordenId == id).
                    Include(d => d.OrdenDetalles).
                    FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ordenes;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> expression)
        {
            List<Ordenes> lista = new List<Ordenes>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Ordenes.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(o => o.ordenId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
