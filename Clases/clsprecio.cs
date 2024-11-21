using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clsprecio
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public precio precio { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.precios.Add(precio);
                bdgestor.SaveChanges();
                return "se insertó el precio con id: " + precio.id_precios;
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
                bdgestor.precios.AddOrUpdate(precio);
                bdgestor.SaveChanges();
                return "Se actualizó el precio con id: " +precio.id_precios;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public precio consultar(int id_precio)
        {
            return bdgestor.precios.FirstOrDefault(p => p.id_precios == id_precio);
        }
        public List<precio> listarprecios()
        {
            return bdgestor.precios.ToList();
        }
        public string eliminar()
        {
            try
            {
                precio _precio = consultar(precio.id_precios);
                if (_precio == null)
                {
                    return "El precio con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.precios.Remove(_precio);
                    bdgestor.SaveChanges();
                    return "Se eliminó el precio con el id : " + precio.id_precios;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}