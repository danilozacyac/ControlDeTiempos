using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;

namespace ControlDeTiempos.Dto
{
    public class Actividades
    {
        private int idActividad;
        private string actividad;
        private bool isSelected;

        public int IdActividad
        {
            get
            {
                return this.idActividad;
            }
            set
            {
                this.idActividad = value;
            }
        }

        public string Actividad
        {
            get
            {
                return this.actividad;
            }
            set
            {
                this.actividad = value;
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
            }
        }

        private string Connection = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Actividades> GetActividades()
        {
            ObservableCollection<Actividades> listaActividades = new ObservableCollection<Actividades>();

            OleDbConnection connection = new OleDbConnection(Connection);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM TipoActividad ORDER BY IdActividad", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Actividades prioridad = new Actividades()
                    {
                        IdActividad = Convert.ToInt32(reader["IdActividad"]),
                        Actividad = reader["Descripcion"].ToString(),
                        IsSelected = false
                    };
                    listaActividades.Add(prioridad);

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

            return listaActividades;
        }
    }
}
