using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clscategoria
    {
        private gestor_dbEntities bdgestor = new gestor_dbEntities();
        public categoria categoria { get; set; }

        public string insertar()
        {
            try
            {
                bdgestor.categorias.Add(categoria);
                bdgestor.SaveChanges();
                return "se insertó la categoria con id: " + categoria.id_categoria;
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
                bdgestor.categorias.AddOrUpdate(categoria);
                bdgestor.SaveChanges();
                return "Se actualizó la categoria con id: " + categoria.id_categoria;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public categoria consultar(int id_categoria)
        {
            return bdgestor.categorias.FirstOrDefault(p => p.id_categoria == id_categoria);
        }
        public List<categoria> listarcategorias()
        {
            return bdgestor.categorias.ToList();
        }
        public string eliminar()
        {
            try
            {
                categoria _categoria = consultar(categoria.id_categoria);
                if (_categoria == null)
                {
                    return "La categoria con el codigo ingresado no existe.";
                }
                else
                {
                    bdgestor.categorias.Remove(_categoria); ;
                    bdgestor.SaveChanges();
                    return "Se eliminó la categoria con el id : " + categoria.id_categoria ;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}