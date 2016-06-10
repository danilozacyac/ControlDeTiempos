using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Graphs;
using ScjnUtilities;
using System.Globalization;

namespace ControlDeTiempos.Model
{
    public class GraficasModel
    {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<NumeroAsuntos> GetTotalAsuntoByMesYear(int mes, int year)
        {
            ObservableCollection<NumeroAsuntos> lista = new ObservableCollection<NumeroAsuntos>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                string sqlQuery = "SELECT Nombre, mMes, mYear, COUNT(IdAbogado) AS Total FROM AsuntosAbogado " +
                                  "WHERE mMes = @Mes AND mYear = @Year " +
                                  "GROUP BY Nombre, mMes, mYear";

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Mes", mes);
                cmd.Parameters.AddWithValue("@Year", year);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    NumeroAsuntos tesis = new NumeroAsuntos()
                    {
                        Nombre = reader["Nombre"].ToString(),
                        Periodo = String.Format("{0} {1}",CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt16(reader["mMes"])), reader["mYear"]),
                        Total = Convert.ToInt32(reader["Total"])
                    };
                    lista.Add(tesis);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GraficasModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GraficasModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return lista;
        }




    }
}
