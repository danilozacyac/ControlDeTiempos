using System;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Dto;
using ScjnUtilities;

namespace ControlDeTiempos.Model
{
    public class AccesoUsuarioModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public bool IsValidUser(string sUsuario, string sPwd)
        {
            bool bExisteUsuario = false;
            string sSql;

            OleDbCommand cmd;
            OleDbDataReader reader;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();

                sSql = "SELECT * FROM Personal WHERE Usuario = @Usuario AND Contrasena = @Contrasena";
                cmd = new OleDbCommand(sSql, connection);
                cmd.Parameters.AddWithValue("@Usuario", sUsuario);
                cmd.Parameters.AddWithValue("@Contrasena", sPwd);
                reader = cmd.ExecuteReader();

                AccesoUsuario.IdUsuario = -1;

                while (reader.Read())
                {
                    AccesoUsuario.IdUsuario = Convert.ToInt32(reader["IdPersonal"]);
                    AccesoUsuario.IdSeccion = Convert.ToInt32(reader["Seccion"]);
                    AccesoUsuario.IdTipoAbogado = Convert.ToInt32(reader["TipoPersonal"]);
                    AccesoUsuario.Usuario = reader["Usuario"].ToString();
                    AccesoUsuario.Nombre = String.Format("{0} {1}", reader["nombre"], reader["Apellidos"]);
                    bExisteUsuario = true;
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AccesoUsuarioModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AccesoUsuarioModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return bExisteUsuario;
        }

        public bool IsValidUser()
        {
            bool bExisteUsuario = false;
            string sSql;

            OleDbCommand cmd;
            OleDbDataReader reader;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();

                sSql = "SELECT * FROM Personal WHERE Usuario = @Usuario";
                cmd = new OleDbCommand(sSql, connection);
                cmd.Parameters.AddWithValue("@Usuario", Environment.UserName);
                reader = cmd.ExecuteReader();

                AccesoUsuario.IdUsuario = -1;

                while (reader.Read())
                {
                    AccesoUsuario.IdUsuario = Convert.ToInt32(reader["IdPersonal"]);
                    AccesoUsuario.IdSeccion = Convert.ToInt32(reader["Seccion"]);
                    AccesoUsuario.IdTipoAbogado = Convert.ToInt32(reader["TipoPersonal"]);
                    AccesoUsuario.Usuario = reader["Usuario"].ToString();
                    AccesoUsuario.Nombre = String.Format("{0} {1}", reader["nombre"], reader["Apellidos"]);
                    bExisteUsuario = true;
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AccesoUsuarioModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AccesoUsuarioModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return bExisteUsuario;
        }

    }
}
