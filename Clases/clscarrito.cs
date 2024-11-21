using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clscarrito
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public carrito carrito { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.carritos.Add(carrito);
                bdgestor.SaveChanges();
                return "se insertó el carrito con id: " + carrito.id_carritos;
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
                bdgestor.carritos.AddOrUpdate(carrito);
                bdgestor.SaveChanges();
                return "Se actualizó el carrito con id: " + carrito.id_carritos;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public carrito consultar(int id_carrito)
        {
            return bdgestor.carritos.FirstOrDefault(p => p.id_carritos == id_carrito);
        }
        public List<carrito> listarcarritos()
        {
            return bdgestor.carritos.ToList();
        }
        public string eliminar()
        {
            try
            {
                carrito _carrito = consultar(carrito.id_carritos);
                if (_carrito == null)
                {
                    return "El carrito con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.carritos.Remove(_carrito); ;
                    bdgestor.SaveChanges();
                    return "Se eliminó el carrito7 con el id : " + carrito.id_carritos;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}