using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;

namespace ControlDeTiempos.Dto
{
    public class PersonalCcst
    {
        private int idPersonal;
        private string nombre;
        private string apellidos;
        private string nombreCompleto;
        private int tipoPersonal;
        private int seccion;

        public int IdPersonal
        {
            get
            {
                return this.idPersonal;
            }
            set
            {
                this.idPersonal = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return this.apellidos;
            }
            set
            {
                this.apellidos = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return this.nombreCompleto;
            }
            set
            {
                this.nombreCompleto = value;
            }
        }

        public int TipoPersonal
        {
            get
            {
                return this.tipoPersonal;
            }
            set
            {
                this.tipoPersonal = value;
            }
        }

        public int Seccion
        {
            get
            {
                return this.seccion;
            }
            set
            {
                this.seccion = value;
            }
        }


        private string Connection = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<PersonalCcst> GetPersonal()
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(Connection);
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
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"],reader["Apellidos"]),
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
    }
}
