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
            [RoutePrefix("api/proveedores")]
            public class proveedorController : ApiController
            {
                [HttpGet]
                [Route("consultar")]

                public proveedore consultar(int id_proveedor)
                {
                    clsproveedor _proveedor = new clsproveedor();
                    return _proveedor.consultar(id_proveedor);
                }
                [HttpGet]
                [Route("listarproveedores")]
                public List<proveedore> listarproveedores()
                {
                    clsproveedor _proveedor = new clsproveedor();
                    return _proveedor.listarprovedores();
                }
                [HttpPost]
                [Route("insertar")]
                public string insertar([FromBody] proveedore proveedor)
                {
                    clsproveedor _proveedor = new clsproveedor();
                    _proveedor.proveedor = proveedor;
                    return _proveedor.insertar();
                }

                [HttpPut]
                [Route("actualizar")]
                public string actualizar([FromBody] proveedore proveedor)
                {
                    clsproveedor _proveedor = new clsproveedor();
                    _proveedor.proveedor = proveedor;
                    return _proveedor.actualizar();
                }
                [HttpDelete]
                [Route("eliminar")]
                public string eliminar([FromBody] proveedore proveedor)
                {
                    clsproveedor _proveedor = new clsproveedor();
                    _proveedor.proveedor = proveedor;
                    return _proveedor.eliminar();
                }
            }
        
    }
