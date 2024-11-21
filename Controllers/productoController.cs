using GESTOR_SERVICIO.Clases;
using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GESTOR_SERVICIO.Controllers
{
    [RoutePrefix("api/productos")]
    public class productoController : ApiController
    {
        [HttpGet]
        [Route("consultar")]

        public producto consultar(int id_producto)
        {
            clsproductos _productos = new clsproductos();
            return _productos.consultar(id_producto);
        }
        [HttpGet]
        [Route("consultarxnombre")]
        public producto consultarxnombre(string nombre)
        {
            clsproductos _productos = new clsproductos();
            return _productos.consultarxnombre(nombre);
        }
        [HttpGet]
        [Route("listar")]
        public IQueryable listar()
        {
            clsproductos _producto = new clsproductos();
            return _producto.listarproductos();
        }
        [HttpPost]
        [Route("insertar")]
        public string insertar([FromBody] producto producto)
        {
            clsproductos _producto = new clsproductos();
            _producto.producto = producto;
            return _producto.insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string actualizar([FromBody] producto producto)
        {
            clsproductos _producto = new clsproductos();
            _producto.producto = producto;
            return _producto.actualizar();
        }
        [HttpDelete]
        [Route("eliminar")]
        public string eliminar([FromBody] producto producto)
        {
            clsproductos _producto = new clsproductos();
            _producto.producto = producto;
            return _producto.eliminar();
        }
    }
}