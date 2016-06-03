using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using ScjnUtilities;

namespace ControlDeTiempos.Dto
{
    public class Prioridades
    {
        private int idPrioridad;
        private string prioridad;
        private string color;

        public int IdPrioridad
        {
            get
            {
                return this.idPrioridad;
            }
            set
            {
                this.idPrioridad = value;
            }
        }

        public string Prioridad
        {
            get
            {
                return this.prioridad;
            }
            set
            {
                this.prioridad = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public ObservableCollection<Prioridades> GetPrioridades()
        {
            ObservableCollection<Prioridades> listaPrioridades = new ObservableCollection<Prioridades>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Prioridad ORDER BY IdPrioridad", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prioridades prioridad = new Prioridades()
                    {
                        IdPrioridad = Convert.ToInt32(reader["IdPrioridad"]),
                        Prioridad = reader["Descripcion"].ToString(),
                        Color = reader["Color"].ToString()
                    };
                    listaPrioridades.Add(prioridad);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Prioridades", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Prioridades", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPrioridades;
        }
    }
}
