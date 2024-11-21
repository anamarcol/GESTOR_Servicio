using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string PaginaSolicitud { get; set; }

    }
    
    public class LoginRespuesta
    {
        public string Role { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
        //public string PaginaInicio { get; set; }
        public bool Autenticado { get; set; }
    }
}