using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clsproducto_carrito
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public productos_carritos producto_c { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.productos_carritos.Add(producto_c);
                bdgestor.SaveChanges();
                return "se insertó el producto del carrito con id: " + producto_c.id_productos_carritos;
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
                bdgestor.productos_carritos.AddOrUpdate(producto_c);
                bdgestor.SaveChanges();
                return "Se actualizó el producto del carrito con id: " + producto_c.id_productos_carritos;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public productos_carritos consultar(int id_producto_carritos)
        {
            return bdgestor.productos_carritos.FirstOrDefault(p => p.id_productos_carritos == id_producto_carritos);
        }
        public List<productos_carritos> listarproductos_carritos()
        {
            return bdgestor.productos_carritos.ToList();
        }
        public string eliminar()
        {
            try
            {
                productos_carritos _producto_c = consultar(producto_c.id_productos_carritos);
                if (_producto_c == null)
                {
                    return "El producto del carrito con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.productos_carritos.Remove(_producto_c); ;
                    bdgestor.SaveChanges();
                    return "Se eliminó el producto del carrito con el id : " + producto_c.id_productos_carritos;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}