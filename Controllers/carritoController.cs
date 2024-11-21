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
    [RoutePrefix("api/carrito")]
    public class carritoController : ApiController
    {
        [HttpGet]
        [Route("consultar")]
        public carrito consultar(int id_carrito)
        {
            clscarrito _carrito = new clscarrito();
            return _carrito.consultar(id_carrito);
        }
        [HttpGet]
        [Route("listarcarritos")]
        public List<carrito> listarcarrito()
        {
            clscarrito _carrito = new clscarrito();
            return _carrito.listarcarritos();
        }
        [HttpPost]
        [Route("insertar")]
        public string insertar([FromBody] carrito carrito)
        {
            clscarrito _carrito = new clscarrito();
            _carrito.carrito = carrito;
            return _carrito.insertar();
        }

        [HttpPut]
        [Route("actualizar")]
        public string actualizar([FromBody] carrito carrito)
        {
            clscarrito _carrito = new clscarrito();
            _carrito.carrito = carrito;
            return _carrito.actualizar();
        }
        [HttpDelete]
        [Route("eliminar")]
        public string eliminar([FromBody] carrito carrito)
        {
            clscarrito _carrito = new clscarrito();
            _carrito.carrito = carrito;
            return _carrito.eliminar();
        }
    }
}