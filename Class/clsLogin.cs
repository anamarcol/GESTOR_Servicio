using GESTOR_SERVICIO.Models;
using System;
using System.Collections.Generic;
using.Linq;
using System.web;

namespace GESTOR_SERVICIO.class
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public DBSuperEntities dbSuper = new DBSuperEntities;  
        public Login login{get; set;}
        public LoginRespuesta loginRespuesta {get; set;}
        public bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Usuario usuario = dbSuper.usuario.FirstOrDefault(u => u.nombre_usuarios == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                } 
                byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt); 
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                login.Clave = ClaveCifrada;
                return true; 
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<loginRespuesta> Consultar()
        {
             if (ValidarUsuario())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return from U in dbSuper.Set<usuario>()
                       join R in dbSuper.Set<role>()
                       on U.id_rol equals R.id_rol
                       //join P in dbSuper.Set<Role>()
                       //on UP.idPerfil equals P.id
                       where U.nombre_usuarios == login.Usuario &&
                             U.clave_usuarios == login.Clave
                       select new LoginRespuesta
                       {
                           Autenticado = true,
                           Perfil = R.nombre_rol,
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