using GESTOR_SERVICIO.Clases;
using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GESTOR_SERVICIO.Controllers
{
    [EnableCors(origins: "https://localhost:58412", headers: "*", methods: "*")]
    [RoutePrefix("api/Login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar([FromBody] Login login)
        {
             clsLogin _login = new clsLogin();
            _login.login = login;
            return _login.Ingresar();
        }
    }
}