using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESTOR_SERVICIO.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public gestor_dbEntities2 dbGestor = new gestor_dbEntities2();
        public Login login {get; set;}
        public LoginRespuesta loginRespuesta {get; set;}
        public bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                usuario Usuario = dbGestor.usuarios.FirstOrDefault(u => u.nombre_usuarios == login.Usuario && u.clave_usuarios == login.Clave);
                if (Usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }

                //string ClaveCifrada = cifrar.HashPassword(login.Clave);
                //login.Clave = ClaveCifrada;
                return true; 
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
             if (ValidarUsuario())
            {               
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbGestor.Set<usuario>()
                       join R in dbGestor.Set<role>()
                       on U.id_rol equals R.id_rol
                       //join P in dbSuper.Set<Role>()
                       //on UP.idPerfil equals P.id
                       where U.nombre_usuarios == login.Usuario &&
                             U.clave_usuarios == login.Clave
                       select new LoginRespuesta
                       {
                           Autenticado = true,
                           Role = R.nombre_rol,
                           //PaginaInicio = U.PaginaNavegar,
                           Token = token,
                           Mensaje = R.nombre_rol.Equals("Empleado") ? "Empleado.html" : "Administrador.html"
                       };
            }
            else
            {
                //return (IQueryable<LoginRespuesta>)loginRespuesta;
                return null;
            }

        }
    }
}