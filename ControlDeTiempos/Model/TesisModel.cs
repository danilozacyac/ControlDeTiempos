using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Dto;
using ScjnUtilities;

namespace ControlDeTiempos.Model
{
    public class TesisModel
    {


        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Tesis> GetTesisByTrabajo(int idTrabajo)
        {
            ObservableCollection<Tesis> listaTesis = new ObservableCollection<Tesis>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Tesis WHERE IdTrabajo = @IdTrabajo", connection);
                cmd.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Tesis tesis = new Tesis()
                    {
                        IdTesis = Convert.ToInt32(reader["IdTesis"]),
                        IdTrabajo = Convert.ToInt32(reader["IdTrabajo"]),
                        NumIdentificacion = reader["NumIdentifica"].ToString(),
                        Paginas = Convert.ToInt32(reader["Paginas"])
                        
                    };
                    listaTesis.Add(tesis);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaTesis;
        }


        public bool SetNewTesis(ref Tesis tesis)
        {
            bool insertCompleted = false;

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            tesis.IdTesis = DataBaseUtilities.GetNextIdForUse("Tesis", "IdTesis", connection);

            try
            {
                if (tesis.IdTesis > 0)
                {
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Tesis WHERE IdTesis = 0", connection);

                    dataAdapter.Fill(dataSet, "Tesis");

                    dr = dataSet.Tables["Tesis"].NewRow();
                    dr["IdTesis"] = tesis.IdTesis;
                    dr["IdTrabajo"] = tesis.IdTrabajo;
                    dr["NumIdentifica"] = tesis.NumIdentificacion;
                    dr["Paginas"] = tesis.Paginas;

                    dataSet.Tables["Tesis"].Rows.Add(dr);

                    dataAdapter.InsertCommand = connection.CreateCommand();
                    dataAdapter.InsertCommand.CommandText = "INSERT INTO Tesis(IdTesis,IdTrabajo,NumIdentifica,Paginas)" +
                                                            " VALUES(@IdTesis,@IdTrabajo,@NumIdentifica,@Paginas)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdTesis", OleDbType.Numeric, 0, "IdTesis");
                    dataAdapter.InsertCommand.Parameters.Add("@IdTrabajo", OleDbType.Numeric, 0, "IdTrabajo");
                    dataAdapter.InsertCommand.Parameters.Add("@NumIdentifica", OleDbType.Numeric, 0, "NumIdentifica");
                    dataAdapter.InsertCommand.Parameters.Add("@Paginas", OleDbType.Numeric, 0, "Paginas");

                    dataAdapter.Update(dataSet, "Tesis");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                    insertCompleted = true;
                }

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TesisModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }
            return insertCompleted;

        }

        public void DeleteTesis(Tesis tesis)
        {
            OleDbConnection oleConne = new OleDbConnection(connectionStr);
            OleDbCommand cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            try
            {
                oleConne.Open();

                cmd.CommandText = "DELETE FROM Tesis WHERE IdTesis = @IdTesis";
                cmd.Parameters.AddWithValue("@IdTesis", tesis.IdTesis);
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, TesisModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, TesisModel", "ControlDeTiempos");
            }
            finally
            {
                cmd.Dispose();
                oleConne.Close();
            }
        }
    }
}
