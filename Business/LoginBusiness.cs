using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace Business
{
    public class LoginBusiness
    {
        public static List<Usuario> List()
        {
            List<Usuario> UsuariosList = new List<Usuario>();
            AccessData data = new AccessData();
            try
            {

                data.SetQuery(@"SELECT UsuarioID, NombreUsuario, Contraseña, Rol FROM Usuarios");
                data.ExecuteQuery();
                while (data.Reader.Read())
                {
                    Usuario usuarioAux = new Usuario()
                    {

                        UsuarioID = (int)data.Reader["UsuarioID"],
                        NombreUsuario = (string)data.Reader["NombreUsuario"],

                        Contraseña = (string)data.Reader["Contraseña"],
                        Rol = (string)data.Reader["Rol"]
                    };
                    UsuariosList.Add(usuarioAux);
                }
                return UsuariosList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.Close();
            }

        }
    }
}





