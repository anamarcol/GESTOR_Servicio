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
        public gestor_dbEntities dbGestor = new gestor_dbEntities();
        public Login login {get; set;}
        public LoginRespuesta loginRespuesta {get; set;}
        public bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Usuario usuario = dbGestor.Usuarios.FirstOrDefault(u => u.nombre_usuarios == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                //byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                //string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
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
                return from U in dbGestor.Set<Usuario>()
                       join R in dbGestor.Set<Role>()
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
                           Mensaje = ""
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