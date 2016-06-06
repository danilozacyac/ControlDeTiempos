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
    public class ErrorModel
    {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;
        private readonly string erroresBasePath = ConfigurationManager.AppSettings["ArchivosErrores"];

        public ObservableCollection<ErrorOperativo> GetErroresByTrabajo(int idTrabajo)
        {
            ObservableCollection<ErrorOperativo> listaErrores = new ObservableCollection<ErrorOperativo>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM ErroresOperativos WHERE IdTrabajo = @IdTrabajo", connection);
                cmd.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ErrorOperativo error = new ErrorOperativo()
                    {
                        IdError = Convert.ToInt32(reader["IdError"]),
                        IdTrabajo = Convert.ToInt32(reader["IdTrabajo"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        NombreArchivo = erroresBasePath + reader["NombreArchivo"],
                        Comentarios = reader["Comentario"].ToString()

                    };
                    listaErrores.Add(error);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ErrorModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ErrorModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaErrores;
        }


        public bool SetNewError(ref ErrorOperativo error)
        {
            bool insertCompleted = false;

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            error.IdError = DataBaseUtilities.GetNextIdForUse("ErroresOperativos", "IdError", connection);

            try
            {
                if (error.IdError > 0)
                {
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM ErroresOperativos WHERE IdError = 0", connection);

                    dataAdapter.Fill(dataSet, "ErroresOperativos");

                    dr = dataSet.Tables["ErroresOperativos"].NewRow();
                    dr["IdError"] = error.IdError;
                    dr["IdTrabajo"] = error.IdTrabajo;
                    dr["Descripcion"] = error.Descripcion;
                    dr["NombreArchivo"] = error.NombreArchivo;
                    dr["Comentario"] = error.Comentarios;
                    dataSet.Tables["ErroresOperativos"].Rows.Add(dr);

                    dataAdapter.InsertCommand = connection.CreateCommand();
                    dataAdapter.InsertCommand.CommandText = "INSERT INTO ErroresOperativos(IdError,IdTrabajo,Descripcion,NombreArchivo,Comentario)" +
                                                            " VALUES(@IdVoto,@IdTrabajo,@Descripcion,@NombreArchivo,@Comentario)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdError", OleDbType.Numeric, 0, "IdError");
                    dataAdapter.InsertCommand.Parameters.Add("@IdTrabajo", OleDbType.Numeric, 0, "IdTrabajo");
                    dataAdapter.InsertCommand.Parameters.Add("@Descripcion", OleDbType.VarChar, 0, "Descripcion");
                    dataAdapter.InsertCommand.Parameters.Add("@NombreArchivo", OleDbType.VarChar, 0, "NombreArchivo");
                    dataAdapter.InsertCommand.Parameters.Add("@Comentario", OleDbType.VarChar, 0, "Comentario");

                    dataAdapter.Update(dataSet, "ErroresOperativos");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                    insertCompleted = true;
                }

            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ErrorModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ErrorModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }
            return insertCompleted;

        }


        public bool UpdateError(ErrorOperativo error)
        {
            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbDataAdapter dataAdapter;
            OleDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;

            bool insertCompleted = false;

            try
            {
                connection.Open();

                DataSet dataSet = new DataSet();
                DataRow dr;

                dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM ErroresOperativos WHERE IdError = @IdError", connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdError", error.IdError);
                dataAdapter.Fill(dataSet, "ErroresOperativos");

                dr = dataSet.Tables["ErroresOperativos"].Rows[0];
                dr.BeginEdit();
                dr["Descripcion"] = error.Descripcion;
                dr["NombreArchivo"] = error.NombreArchivo;
                dr["Comentario"] = error.Comentarios;

                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE ErroresOperativos SET Descripcion = @Descripcion, NombreArchivo = @NombreArchivo," +
                    "Comentario = @Comentario WHERE IdError = @IdError";

                dataAdapter.UpdateCommand.Parameters.Add("@Descripcion", OleDbType.VarChar, 0, "Descripcion");
                dataAdapter.UpdateCommand.Parameters.Add("@NombreArchivo", OleDbType.VarChar, 0, "NombreArchivo");
                dataAdapter.UpdateCommand.Parameters.Add("@Comentario", OleDbType.VarChar, 0, "Comentario");
                dataAdapter.UpdateCommand.Parameters.Add("@IdError", OleDbType.Numeric, 0, "IdError");

                dataAdapter.Update(dataSet, "ErroresOperativos");

                dataSet.Dispose();
                dataAdapter.Dispose();

                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ErrorModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ErrorModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }


        public void DeleteError(ErrorOperativo error)
        {
            OleDbConnection oleConne = new OleDbConnection(connectionStr);
            OleDbCommand cmd = oleConne.CreateCommand();
            cmd.Connection = oleConne;

            try
            {
                oleConne.Open();

                cmd.CommandText = "DELETE FROM ErroresOperativos WHERE IdError = @IdError";
                cmd.Parameters.AddWithValue("@IdError", error.IdError);
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, ErrorModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception, ErrorModel", "ControlDeTiempos");
            }
            finally
            {
                cmd.Dispose();
                oleConne.Close();
            }
        }

    }
}
