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
        [RoutePrefix("api/precios")]
        public class preciosController : ApiController
        {
            [HttpGet]
            [Route("consultar")]

            public precio consultar(int id_precio)
            {
                clsprecio _precio = new clsprecio();
                return _precio.consultar(id_precio);
            }
            [HttpGet]
            [Route("listarprecios")]
            public List<precio> listarprecios()
            {
                clsprecio _precio = new clsprecio();
                return _precio.listarprecios();
            }
            [HttpPost]
            [Route("insertar")]
            public string insertar([FromBody] precio precio)
            {
                clsprecio _precio = new clsprecio();
                _precio.precio = precio;
                return _precio.insertar();
            }

            [HttpPut]
            [Route("actualizar")]
            public string actualizar([FromBody] precio precio)
            {
                clsprecio _precio = new clsprecio();
                _precio.precio = precio;
                return _precio.actualizar();
            }
            [HttpDelete]
            [Route("eliminar")]
            public string eliminar([FromBody] precio precio)
            {
                clsprecio _precio = new clsprecio();
                _precio.precio = precio;
                return _precio.eliminar();
            }
        }
    }
