using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clsproveedor
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();

        public proveedore proveedor { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.proveedores.Add(proveedor);
                bdgestor.SaveChanges();
                return "se insertó el proveedor con id: " + proveedor.id_proveedor;
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
                bdgestor.proveedores.AddOrUpdate(proveedor);
                bdgestor.SaveChanges();
                return "Se actualizó el proveedor con id: " + proveedor.id_proveedor;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public proveedore consultar(int id_proveedor)
        {
            return bdgestor.proveedores.FirstOrDefault(p => p.id_proveedor == id_proveedor);
        }
        public List<proveedore> listarprovedores()
        {
            return bdgestor.proveedores.ToList();
        }
        public string eliminar()
        {
            try
            {
                proveedore _proveedor = consultar(proveedor.id_proveedor);
                if (_proveedor == null)
                {
                    return "El proveedor con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.proveedores.Remove(_proveedor); ;
                    bdgestor.SaveChanges();
                    return "Se eliminó el proveedor con el id : " + proveedor.id_proveedor;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}