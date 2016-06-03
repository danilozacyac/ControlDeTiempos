using ControlDeTiempos.Dto;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace ControlDeTiempos.Model
{
    public class TrabajoAsignadoModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<TrabajoAsignado> GetTrabajos()
        {
            ObservableCollection<TrabajoAsignado> listaTrabajos = new ObservableCollection<TrabajoAsignado>();

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Trabajo ORDER BY FechaIndicada Desc", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TrabajoAsignado trabajo = new TrabajoAsignado()
                    {
                        IdTrabajo = Convert.ToInt32(reader["IdTrabajo"]),
                        IdAbogado = Convert.ToInt32(reader["IdAbogado"]),
                        TipoDocumento = Convert.ToInt32(reader["TipoDocumento"]),
                        IdActividad = Convert.ToInt32(reader["IdActividad"]),
                        OtraActividad = reader["OtraActividad"].ToString(),
                        Particularidades = reader["Particularidades"].ToString(),
                        IdPrioridad = Convert.ToInt32(reader["IdPrioridad"]),
                        FechaInicio = DateTimeUtilities.GetDateFromReader(reader, "FechaInicio"),
                        FechaIndicada = DateTimeUtilities.GetDateFromReader(reader, "FechaIndicada"),
                        FechaEntrega = DateTimeUtilities.GetDateFromReader(reader, "FechaEntrega"),
                        EnTiempo = Convert.ToInt32(reader["EnTiempo"]),
                        IdOperativo = Convert.ToInt32(reader["IdPerOperativo"]),
                        ServicioSocial = reader["ServicioSocial"].ToString(),
                        IdQuienAsigna = Convert.ToInt32(reader["IdQuienAsigna"]),
                        PaginasEjecutoria = Convert.ToInt32(reader["PaginasEjecutoria"]),
                        NumExpediente = Convert.ToInt32(reader["NumExpediente"]),
                        AnioExpediente = Convert.ToInt32(reader["AnioExpediente"]),
                        IdTipoAsunto = Convert.ToInt32(reader["IdTipoAsunto"])
                    };
                    listaTrabajos.Add(trabajo);

                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TrabajoAsignadoModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TrabajoAsignadoModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaTrabajos;
        }


        public bool SetNewTrabajo(ref TrabajoAsignado trabajo)
        {
            bool insertCompleted = false;

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataAdapter dataAdapter;

            DataSet dataSet = new DataSet();
            DataRow dr;

            trabajo.IdTrabajo = DataBaseUtilities.GetNextIdForUse("Trabajo", "IdTrabajo", connection);

            try
            {
                if (trabajo.IdTrabajo > 0)
                {
                    dataAdapter = new OleDbDataAdapter();
                    dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Trabajo WHERE IdTrabajo = 0", connection);

                    dataAdapter.Fill(dataSet, "Trabajo");

                    dr = dataSet.Tables["Trabajo"].NewRow();
                    dr["IdTrabajo"] = trabajo.IdTrabajo;
                    dr["IdAbogado"] = trabajo.IdAbogado;
                    dr["TipoDocumento"] = trabajo.TipoDocumento;
                    dr["IdActividad"] = trabajo.IdActividad;
                    dr["OtraActividad"] = trabajo.OtraActividad;
                    dr["Particularidades"] = trabajo.Particularidades;
                    dr["IdPrioridad"] = trabajo.IdPrioridad;
                    dr["FechaInicio"] = trabajo.FechaInicio;
                    dr["FechaInicioInt"] = DateTimeUtilities.DateToInt(trabajo.FechaInicio);
                    dr["FechaIndicada"] = trabajo.FechaIndicada;
                    dr["FechaIndicadaInt"] = DateTimeUtilities.DateToInt(trabajo.FechaIndicada);
                    dr["IdPerOperativo"] = trabajo.IdOperativo;
                    dr["ServicioSocial"] = trabajo.ServicioSocial;
                    dr["IdQuienAsigna"] = trabajo.IdQuienAsigna;
                    dr["PaginasEjecutoria"] = trabajo.PaginasEjecutoria;
                    dr["IdTipoAsunto"] = trabajo.IdTipoAsunto;
                    dr["NumExpediente"] = trabajo.NumExpediente;
                    dr["AnioExpediente"] = trabajo.AnioExpediente;

                    dataSet.Tables["Trabajo"].Rows.Add(dr);

                    dataAdapter.InsertCommand = connection.CreateCommand();
                    dataAdapter.InsertCommand.CommandText = "INSERT INTO Trabajo(IdTrabajo,IdAbogado,TipoDocumento,IdActividad,OtraActividad,Particularidades,IdPrioridad,FechaInicio,FechaInicioInt,FechaIndicada,FechaIndicadaInt,IdPerOperativo,ServicioSocial,IdQuienAsigna,PaginasEjecutoria,IdTipoAsunto,NumExpediente,AnioExpediente)" +
                                                            " VALUES(@IdTrabajo,@IdAbogado,@TipoDocumento,@IdActividad,@OtraActividad,@Particularidades,@IdPrioridad,@FechaInicio,@FechaInicioInt,@FechaIndicada,@FechaIndicadaInt,@IdPerOperativo,@ServicioSocial,@IdQuienAsigna,@PaginasEjecutoria,@IdTipoAsunto,@NumExpediente,@AnioExpediente)";

                    dataAdapter.InsertCommand.Parameters.Add("@IdTrabajo", OleDbType.Numeric, 0, "IdTrabajo");
                    dataAdapter.InsertCommand.Parameters.Add("@IdAbogado", OleDbType.Numeric, 0, "IdAbogado");
                    dataAdapter.InsertCommand.Parameters.Add("@TipoDocumento", OleDbType.Numeric, 0, "TipoDocumento");
                    dataAdapter.InsertCommand.Parameters.Add("@IdActividad", OleDbType.Numeric, 0, "IdActividad");
                    dataAdapter.InsertCommand.Parameters.Add("@OtraActividad", OleDbType.VarChar, 0, "OtraActividad");
                    dataAdapter.InsertCommand.Parameters.Add("@Particularidades", OleDbType.VarChar, 0, "Particularidades");
                    dataAdapter.InsertCommand.Parameters.Add("@IdPrioridad", OleDbType.Numeric, 0, "IdPrioridad");
                    dataAdapter.InsertCommand.Parameters.Add("@FechaInicio", OleDbType.Date, 0, "FechaInicio");
                    dataAdapter.InsertCommand.Parameters.Add("@FechaInicioInt", OleDbType.Numeric, 0, "FechaInicioInt");
                    dataAdapter.InsertCommand.Parameters.Add("@FechaIndicada", OleDbType.Date, 0, "FechaIndicada");
                    dataAdapter.InsertCommand.Parameters.Add("@FechaIndicadaInt", OleDbType.Numeric, 0, "FechaIndicadaInt");
                    dataAdapter.InsertCommand.Parameters.Add("@IdPerOperativo", OleDbType.Numeric, 0, "IdPerOperativo");
                    dataAdapter.InsertCommand.Parameters.Add("@ServicioSocial", OleDbType.VarChar, 0, "ServicioSocial");
                    dataAdapter.InsertCommand.Parameters.Add("@IdQuienAsigna", OleDbType.Numeric, 0, "IdQuienAsigna");
                    dataAdapter.InsertCommand.Parameters.Add("@PaginasEjecutoria", OleDbType.Numeric, 0, "PaginasEjecutoria");
                    dataAdapter.InsertCommand.Parameters.Add("@IdTipoAsunto", OleDbType.Numeric, 0, "IdTipoAsunto");
                    dataAdapter.InsertCommand.Parameters.Add("@NumExpediente", OleDbType.Numeric, 0, "NumExpediente");
                    dataAdapter.InsertCommand.Parameters.Add("@AnioExpediente", OleDbType.Numeric, 0, "AnioExpediente");

                    dataAdapter.Update(dataSet, "Trabajo");

                    dataSet.Dispose();
                    dataAdapter.Dispose();
                    insertCompleted = true;
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TrabajoAsignadoModel", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TrabajoAsignadoModel", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }


        public bool UpdateTrabajo(TrabajoAsignado trabajo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
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
                dataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Trabajo WHERE IdTrabajo = @IdTrabajo", connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@IdTrabajo", trabajo.IdTrabajo);
                dataAdapter.Fill(dataSet, "Trabajo");

                dr = dataSet.Tables["Trabajo"].Rows[0];
                dr.BeginEdit();
                dr["IdTrabajo"] = trabajo.IdTrabajo;
                dr["IdAbogado"] = trabajo.IdAbogado;
                dr["TipoDocumento"] = trabajo.TipoDocumento;
                dr["IdActividad"] = trabajo.IdActividad;
                dr["OtraActividad"] = trabajo.OtraActividad;
                dr["Particularidades"] = trabajo.Particularidades;
                dr["IdPrioridad"] = trabajo.IdPrioridad;
                dr["FechaInicio"] = trabajo.FechaInicio;
                dr["FechaInicioInt"] = DateTimeUtilities.DateToInt(trabajo.FechaInicio);
                dr["FechaIndicada"] = trabajo.FechaIndicada;
                dr["FechaIndicadaInt"] = DateTimeUtilities.DateToInt(trabajo.FechaIndicada);
                dr["IdPerOperativo"] = trabajo.IdOperativo;
                dr["ServicioSocial"] = trabajo.ServicioSocial;
                dr["IdQuienAsigna"] = trabajo.IdQuienAsigna;
                dr["PaginasEjecutoria"] = trabajo.PaginasEjecutoria;

                if (trabajo.FechaEntrega == null)
                {
                    dr["FechaEntrega"] = DBNull.Value;
                    dr["FechaEntregaInt"] = 0;
                }
                else
                {
                    dr["FechaEntrega"] = trabajo.FechaEntrega;
                    dr["FechaEntregaInt"] = DateTimeUtilities.DateToInt(trabajo.FechaEntrega);
                }
                dr["IdTipoAsunto"] = trabajo.IdTipoAsunto;
                dr["NumExpediente"] = trabajo.NumExpediente;
                dr["AnioExpediente"] = trabajo.AnioExpediente;
                dr.EndEdit();

                dataAdapter.UpdateCommand = connection.CreateCommand();

                dataAdapter.UpdateCommand.CommandText = "UPDATE Trabajo SET IdAbogado = @IdAbogado, TipoDocumento = @TipoDocumento," +
                    "IdActividad = @IdActividad,OtraActividad = @OtraActividad,Particularidades = @Particularidades, " +
                    "IdPrioridad = @IdPrioridad, FechaInicio = @FechaInicio, FechaInicioInt = @FechaInicioInt," +
                    "FechaIndicada = @FechaIndicada, FechaIndicadaInt = @FechaIndicadaInt,IdPerOperativo = @IdPerOperativo," +
                    "ServicioSocial = @ServicioSocial,IdQuienAsigna = @IdQuienAsigna, PaginasEjecutoria = @PaginasEjecutoria, " +
                    "FechaEntrega = @FechaEntrega, FechaEntregaInt = @FechaEntregaInt,IdTipoAsunto = @IdTipoAsunto,NumExpediente = @NumExpediente,AnioExpediente = @AnioExpediente " +
                    " WHERE IdTrabajo = @IdTrabajo";

                dataAdapter.UpdateCommand.Parameters.Add("@IdAbogado", OleDbType.Numeric, 0, "IdAbogado");
                dataAdapter.UpdateCommand.Parameters.Add("@TipoDocumento", OleDbType.Numeric, 0, "TipoDocumento");
                dataAdapter.UpdateCommand.Parameters.Add("@IdActividad", OleDbType.Numeric, 0, "IdActividad");
                dataAdapter.UpdateCommand.Parameters.Add("@OtraActividad", OleDbType.VarChar, 0, "OtraActividad");
                dataAdapter.UpdateCommand.Parameters.Add("@Particularidades", OleDbType.VarChar, 0, "Particularidades");
                dataAdapter.UpdateCommand.Parameters.Add("@IdPrioridad", OleDbType.Numeric, 0, "IdPrioridad");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaInicio", OleDbType.Date, 0, "FechaInicio");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaInicioInt", OleDbType.Numeric, 0, "FechaInicioInt");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaIndicada", OleDbType.Date, 0, "FechaIndicada");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaIndicadaInt", OleDbType.Numeric, 0, "FechaIndicadaInt");
                dataAdapter.UpdateCommand.Parameters.Add("@IdPerOperativo", OleDbType.Numeric, 0, "IdPerOperativo");
                dataAdapter.UpdateCommand.Parameters.Add("@ServicioSocial", OleDbType.VarChar, 0, "ServicioSocial");
                dataAdapter.UpdateCommand.Parameters.Add("@IdQuienAsigna", OleDbType.Numeric, 0, "IdQuienAsigna");
                dataAdapter.UpdateCommand.Parameters.Add("@PaginasEjecutoria", OleDbType.Numeric, 0, "PaginasEjecutoria");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaEntrega", OleDbType.Date, 0, "FechaEntrega");
                dataAdapter.UpdateCommand.Parameters.Add("@FechaEntregaInt", OleDbType.Numeric, 0, "FechaEntregaInt");
                dataAdapter.InsertCommand.Parameters.Add("@IdTipoAsunto", OleDbType.Numeric, 0, "IdTipoAsunto");
                dataAdapter.InsertCommand.Parameters.Add("@NumExpediente", OleDbType.Numeric, 0, "NumExpediente");
                dataAdapter.InsertCommand.Parameters.Add("@AnioExpediente", OleDbType.Numeric, 0, "AnioExpediente");
                dataAdapter.UpdateCommand.Parameters.Add("@IdTrabajo", OleDbType.Numeric, 0, "IdTrabajo");

                dataAdapter.Update(dataSet, "Trabajo");

                dataSet.Dispose();
                dataAdapter.Dispose();

                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TrabajoAsignadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TrabajoAsignadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }

    }
}
