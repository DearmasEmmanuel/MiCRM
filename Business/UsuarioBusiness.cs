using System;
using System.Collections.Generic;
using Dominio;

namespace Business
{
    public class UsuarioBusiness
    {
        public static List<Usuario> List()
        {
            // Aquí implementa la lógica para obtener la lista de usuarios desde la base de datos
            // Puedes utilizar consultas SQL u ORM como Entity Framework

           
            AccessData data = new AccessData();
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                data.SetQuery("select UsuarioID, NombreUsuario, Contraseña, Rol from Usuarios");
                data.ExecuteQuery();
                while (data.Reader.Read())
                {
                    Usuario usuario = new Usuario()
                    {
                        UsuarioID = (int)data.Reader["UsuarioID"],
                        NombreUsuario = data.Reader["NombreUsuario"].ToString(),
                        Contraseña = data.Reader["Contraseña"].ToString(),
                        Rol = data.Reader["Rol"].ToString()
                    };
                        }
            } catch (Exception ex1)
            {
                throw new Exception("Error al listar los artículos.", ex1);
            }
                   
                    return listaUsuarios;
        }

        public static void CrearUsuario(Usuario usuario)
        {
            AccessData data = new AccessData();
            try
            {
                string query = "Insert into Usuarios ( NombreUsuario, Contraseña, Rol) values (@NombreUsuario,@Contraseña, @Rol)";
                data.SetQuery(query);
                data.AddParameter("@NombreUsuario",usuario.NombreUsuario);
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

     
        
    }
}

