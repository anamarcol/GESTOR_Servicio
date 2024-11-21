using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clsproducto_venta
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public productos_ventas producto_v { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.productos_ventas.Add(producto_v);
                bdgestor.SaveChanges();
                return "se insertó el producto de la venta con id: " + producto_v.id_producto_ventas;
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
                bdgestor.productos_ventas.AddOrUpdate(producto_v);
                bdgestor.SaveChanges();
                return "Se actualizó el producto de la venta con id: " + producto_v.id_producto_ventas;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public productos_ventas consultar(int id_producto_venta)
        {
            return bdgestor.productos_ventas.FirstOrDefault(p => p.id_producto_ventas == id_producto_venta);
        }
        public List<productos_ventas> listarproductos_ventas()
        {
            return bdgestor.productos_ventas.ToList();
        }
        public string eliminar()
        {
            try
            {
                productos_ventas _producto_v = consultar(producto_v.id_producto_ventas);
                if (_producto_v == null)
                {
                    return "El producto de la venta con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.productos_ventas.Remove(_producto_v); ;
                    bdgestor.SaveChanges();
                    return "Se eliminó el producto de la venta con el id : " + producto_v.id_producto_ventas;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}