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
        [RoutePrefix("api/categorias")]
        public class categoriaController : ApiController
        {
            [HttpGet]
            [Route("consultar")]

            public categoria consultar(int id_categoria)
            { 
                clscategoria _categoria = new clscategoria();
                return _categoria.consultar(id_categoria); 
            }
            [HttpGet]
            [Route("listarcategorias")]
            public List<categoria> listarcategorias()
            {
                clscategoria _categoria = new clscategoria();
                return _categoria.listarcategorias();
            }
            [HttpPost]
            [Route("insertar")]
            public string insertar([FromBody] categoria categoria)
            {
                clscategoria _categoria = new clscategoria();
                _categoria.categoria = categoria;
                return _categoria.insertar();
            }

            [HttpPut]
            [Route("actualizar")]
            public string actualizar([FromBody] categoria categoria)
            {
                clscategoria _categoria = new clscategoria();
                _categoria.categoria = categoria;
                return _categoria.actualizar();
            }
            [HttpDelete]
            [Route("eliminar")]
            public string eliminar([FromBody] categoria categoria)
            {
                clscategoria _categoria = new clscategoria();
                _categoria.categoria = categoria;
                return _categoria.eliminar();
            }
        }
    }
