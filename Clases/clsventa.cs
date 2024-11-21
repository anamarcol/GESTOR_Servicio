using GESTOR_SERVICIO.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GESTOR_SERVICIO.Clases
{
    [RoutePrefix("api/ventas")]
    public class clsventa
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public venta venta { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.ventas.Add(venta);
                bdgestor.SaveChanges();
                return "se insertó la venta con id: " + venta.no_factura;
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
                bdgestor.ventas.AddOrUpdate(venta);
                bdgestor.SaveChanges();
                return "Se actualizó la venta con id: " + venta.no_factura;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public venta consultar(int no_factura)
        {
            return bdgestor.ventas.FirstOrDefault(p => p.no_factura == no_factura);
        }
        public List<venta> listarventas()
        {
            return bdgestor.ventas.ToList();
        }
        public string eliminar()
        {
            try
            {
                venta _venta = consultar(venta.no_factura);
                if (_venta == null)
                {
                    return "La venta con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.ventas.Remove(_venta); ;
                    bdgestor.SaveChanges();
                    return "Se eliminó la venta con el id : " + venta.no_factura;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}