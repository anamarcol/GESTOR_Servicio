using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clsproductos
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public producto producto { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.productos.Add(producto);
                bdgestor.SaveChanges();
                return "se insertó el producto con id: " + producto.id_producto;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string actualizar()
        {
            try
            {
                bdgestor.productos.AddOrUpdate(producto);
                bdgestor.SaveChanges();
                return "Se actualizó el producto con id: " + producto.id_producto;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public producto consultar(int id_producto)
        {
            return bdgestor.productos.FirstOrDefault(p => p.id_producto == id_producto);
        }
        public producto consultarxnombre(string nombre)
        {
            return bdgestor.productos.FirstOrDefault(p=> p.nombre_producto == nombre);
        }
        public string eliminar()
        {
            try
            {
                producto _producto = consultar(producto.id_producto);
                if (_producto == null)
                {
                    return "El producto con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.productos.Remove(_producto);
                    bdgestor.SaveChanges();
                    return "Se eliminó el seguro con el id : " + producto.id_producto; 
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public IQueryable listarproductos()
        {
            return  from p in bdgestor.Set<producto>()
                          join pr in bdgestor.Set<precio>() on p.id_precio equals pr.id_precios
                          join c in bdgestor.Set<categoria>() on p.id_categoria equals c.id_categoria
                          join prov in bdgestor.Set<proveedore>() on p.id_proveedor equals prov.id_proveedor
                          select new
                          {
                              id_producto = p.id_producto,
                              nombre_producto = p.nombre_producto,
                              caracteristicas_producto = p.caracteristicas_producto,
                              stock = p.stock,
                              descripcion = p.descripcion,
                              precio_venta = pr.precio_venta,
                              nombre_categorias = c.nombre_categorias,
                              nombre_proveedor = prov.nombre_proveedor
                          };
        }
    }
}