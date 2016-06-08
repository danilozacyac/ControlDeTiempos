using System;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Dto;
using ScjnUtilities;
using System.Configuration;

namespace ControlDeTiempos.Model
{
    public class PersonalModel
    {
        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public ObservableCollection<PersonalCcst> GetPersonal()
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal ORDER BY IdPersonal", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonalCcst personal = new PersonalCcst()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"], reader["Apellidos"]),
                        TipoPersonal = Convert.ToInt32(reader["TipoPersonal"]),
                        Seccion = Convert.ToInt32(reader["Seccion"])
                    };
                    listaPersonal.Add(personal);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }


        public ObservableCollection<PersonalCcst> GetPersonal( int idTipoPersonal)
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal WHERE TipoPersonal = @TipoPersonal ORDER BY IdPersonal", connection);
                cmd.Parameters.AddWithValue("@TipoPersonal", idTipoPersonal);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonalCcst personal = new PersonalCcst()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"], reader["Apellidos"]),
                        TipoPersonal = Convert.ToInt32(reader["TipoPersonal"]),
                        Seccion = Convert.ToInt32(reader["Seccion"])
                    };
                    listaPersonal.Add(personal);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }


        public ObservableCollection<PersonalCcst> GetPersonalForFilter()
        {
            ObservableCollection<PersonalCcst> personal = new ObservableCollection<PersonalCcst>();

            PersonalCcst abogados = new PersonalCcst()
            {
                NombreCompleto = "Abogados responsables",
                IdPersonal = 10000,
                Child = GetPersonal(1)
            };

            PersonalCcst operativos = new PersonalCcst()
            {
                NombreCompleto = "Personal operativo",
                IdPersonal = 10001,
                Child = GetPersonal(3)
            };

            personal.Add(abogados);
            personal.Add(operativos);

            return personal;
        }
    }
}
