using ControlDeTiempos.Dto;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTiempos.Model
{
    public class VotosModel
    {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Voto> GetVotosByTrabajo(int idTrabajo)
        {
            ObservableCollection<Voto> listaVotos = null;

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Voto WHERE IdTrabajo = @IdTrabajo", connection);
                cmd.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if(listaVotos == null)
                        listaVotos = new ObservableCollection<Voto>();

                    Voto tesis = new Voto()
                    {
                        IdVoto = Convert.ToInt32(reader["IdVoto"]),
                        IdTrabajo = Convert.ToInt32(reader["IdTrabajo"]),
                        IdEmisor = Convert.ToInt32(reader["IdEmisor"]),
                        IdTipoVoto = Convert.ToInt32(reader["IdTipoVoto"]),
                        Paginas = Convert.ToInt32(reader["Paginas"])

                    };
                    listaVotos.Add(tesis);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaVotos;
        }


        public bool SetNewVoto(Voto voto)
        {
            bool insertCompleted = false;

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            voto.IdVoto = DataBaseUtilities.GetNextIdForUse("Voto", "IdVoto", connection);

            try
            {
                if (voto.IdVoto > 0)
                {
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Voto WHERE IdVoto = 0", connection);

                    dataAdapter.Fill(dataSet, "Voto");

                    dr = dataSet.Tables["Voto"].NewRow();
                    dr["IdVoto"] = voto.IdVoto;
                    dr["IdTrabajo"] = voto.IdTrabajo;
                    dr["Paginas"] = voto.Paginas;
                    dr["IdEmisor"] = voto.IdEmisor;
                    dr["IdTipoVoto"] = voto.IdTipoVoto;
                    dataSet.Tables["Voto"].Rows.Add(dr);

                    dataAdapter.InsertCommand = connection.CreateCommand();
                    dataAdapter.InsertCommand.CommandText = "INSERT INTO Voto(IdVoto,IdTrabajo,Paginas,IdEmisor,IdTipoVoto)" +
                                                            " VALUES(@IdVoto,@IdTrabajo,@Paginas,@IdEmisor,@IdTipoVoto)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdVoto", OleDbType.Numeric, 0, "IdVoto");
                    dataAdapter.InsertCommand.Parameters.Add("@IdTrabajo", OleDbType.Numeric, 0, "IdTrabajo");
                    dataAdapter.InsertCommand.Parameters.Add("@Paginas", OleDbType.Numeric, 0, "Paginas");
                    dataAdapter.InsertCommand.Parameters.Add("@IdEmisor", OleDbType.Numeric, 0, "IdEmisor");
                    dataAdapter.InsertCommand.Parameters.Add("@IdTipoVoto", OleDbType.Numeric, 0, "IdTipoVoto");

                    dataAdapter.Update(dataSet, "Voto");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                    insertCompleted = true;
                }

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,VotosModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }
            return insertCompleted;

        }

        public void DeleteVoto(Voto voto)
        {
            OleDbConnection oleConne = new OleDbConnection(connectionStr);
            OleDbCommand cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            try
            {
                oleConne.Open();

                cmd.CommandText = "DELETE FROM Voto WHERE IdVoto = @IdVoto";
                cmd.Parameters.AddWithValue("@IdVoto", voto.IdVoto);
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, VotosModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, VotosModel", "ControlDeTiempos");
            }
            finally
            {
                cmd.Dispose();
                oleConne.Close();
            }
        }

    }
}
