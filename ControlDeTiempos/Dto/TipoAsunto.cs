using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;

namespace ControlDeTiempos.Dto
{
    public class TipoAsunto
    {
        private int idTipoAsunto;
        private string descripcion;
        private string nombreCorto;
        private int activo;
        private string abreviatura;

        public int IdTipoAsunto
        {
            get
            {
                return this.idTipoAsunto;
            }
            set
            {
                this.idTipoAsunto = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public string NombreCorto
        {
            get
            {
                return this.nombreCorto;
            }
            set
            {
                this.nombreCorto = value;
            }
        }

        public int Activo
        {
            get
            {
                return this.activo;
            }
            set
            {
                this.activo = value;
            }
        }

        public string Abreviatura
        {
            get
            {
                return this.abreviatura;
            }
            set
            {
                this.abreviatura = value;
            }
        }


        private string Connection = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<TipoAsunto> GetTipoAsunto()
        {
            ObservableCollection<TipoAsunto> listatipos = new ObservableCollection<TipoAsunto>();

            OleDbConnection connection = new OleDbConnection(Connection);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM TipoAsunto ORDER BY IdTipoAsunto", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoAsunto prioridad = new TipoAsunto()
                    {
                        IdTipoAsunto = Convert.ToInt32(reader["IdTipoAsunto"]),
                        Descripcion = reader["TipoAsunto"].ToString(),
                        NombreCorto = reader["NombreCorto"].ToString(),
                        Activo = Convert.ToInt16(reader["Activo"]),
                        Abreviatura = reader["Abreviatura"].ToString()
                    };
                    listatipos.Add(prioridad);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,tipoAsunto", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TipoAsunto", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listatipos;
        }


        public ObservableCollection<TipoAsunto> GetTipoVoto()
        {
            ObservableCollection<TipoAsunto> listaVotos = new ObservableCollection<TipoAsunto>();

            OleDbConnection connection = new OleDbConnection(Connection);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM TipoVoto ORDER BY IdTipoVoto", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoAsunto prioridad = new TipoAsunto()
                    {
                        IdTipoAsunto = Convert.ToInt32(reader["IdTipoVoto"]),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                    listaVotos.Add(prioridad);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,tipoAsunto", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TipoAsunto", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaVotos;
        }

    }
}
