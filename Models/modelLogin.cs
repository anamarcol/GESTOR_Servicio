using System;
using System.Collections.Generic;
using.Linq;
using System.web;

namespace GESTOR_SERVICIO.class
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
        public string PaginaInicio { get; set; }
        public bool Autenticado { get; set; }
    }
}