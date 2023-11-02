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

        public static void AgregarUsuario(Usuario usuario)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la inserción del nuevo usuario en la base de datos
                string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Rol) VALUES (@NombreUsuario, @Contraseña, @Rol)";
                data.SetQuery(query);
                data.AddParameter("@NombreUsuario", usuario.NombreUsuario);
                data.AddParameter("@Contraseña", usuario.Contraseña);
                data.AddParameter("@Rol", usuario.Rol);
                data.ExecuteNonQuery();
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

        public static void EditarUsuario(Usuario usuario)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la actualización del usuario en la base de datos
                string query = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Rol = @Rol WHERE UsuarioID = @UsuarioID";
                data.SetQuery(query);
                data.AddParameter("@UsuarioID", usuario.UsuarioID);
                data.AddParameter("@NombreUsuario", usuario.NombreUsuario);
                data.AddParameter("@Contraseña", usuario.Contraseña);
                data.AddParameter("@Rol", usuario.Rol);
                data.ExecuteNonQuery();
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

        public static void EliminarUsuario(int usuarioID)
        {
            AccessData data = new AccessData();
            try
            {
                // Realiza la eliminación del usuario en la base de datos
                string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                data.SetQuery(query);
                data.AddParameter("@UsuarioID", usuarioID);
                data.ExecuteNonQuery();
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





