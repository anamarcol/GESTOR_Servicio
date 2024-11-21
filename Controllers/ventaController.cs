using GESTOR_SERVICIO.Clases;
using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace GESTOR_SERVICIO.Controllers
{
    public class ventaController : ApiController
    {
        [HttpGet]
        [Route("consultar")]

        public venta consultar(int id_venta)
        {
            clsventa _venta = new clsventa();
            return _venta.consultar(id_venta);
        }
        [HttpGet]
        [Route("listarventas")]
        public List<venta> listarventas()
        {
            clsventa _venta = new clsventa();
            return _venta.listarventas();
        }
        [HttpPost]
        [Route("insertar")]
        public string insertar([FromBody] venta venta)
        {
            clsventa _venta = new clsventa();
            _venta.venta = venta;
            return _venta.insertar();
        }

        [HttpPut]
        [Route("actualizar")]
        public string actualizar([FromBody] venta venta)
        {
            clsventa _venta = new clsventa();
            _venta.venta = venta;
            return _venta.actualizar();
        }
        [HttpDelete]
        [Route("eliminar")]
        public string eliminar([FromBody] venta venta)
        {
            clsventa _venta = new clsventa();
            _venta.venta = venta;
            return _venta.eliminar();
        }
    }
}