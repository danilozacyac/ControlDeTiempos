using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;

namespace ControlDeTiempos.Dto
{
    public class Emisor
    {
        private int idEmisor;
        private string nombre;
        private string apellidos;
        private string nombreCompleto;
        private int idSeccion;
        public int IdEmisor
        {
            get
            {
                return this.idEmisor;
            }
            set
            {
                this.idEmisor = value;
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

        public int IdSeccion
        {
            get
            {
                return this.idSeccion;
            }
            set
            {
                this.idSeccion = value;
            }
        }


        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public ObservableCollection<Emisor> GetEmisor()
        {
            ObservableCollection<Emisor> listaEmisores = new ObservableCollection<Emisor>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Emisores ORDER BY IdEmisor", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Emisor prioridad = new Emisor()
                    {
                        IdEmisor = Convert.ToInt32(reader["IdEmisor"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"],reader["Apellidos"]),
                        IdSeccion = Convert.ToInt32(reader["Seccion"])
                    };
                    listaEmisores.Add(prioridad);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Emisor", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Emisor", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaEmisores;
        }
    }
}
