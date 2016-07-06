﻿using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Graphs;
using ScjnUtilities;
using System.Globalization;
using System.Collections.Generic;
using DevExpress.Xpf.Charts;
using ControlDeTiempos.Graphs.Particulares.Operativos;

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
                        Periodo = String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt16(reader["mMes"])), reader["mYear"]),
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

        /// <summary>
        /// Devuelve el número de asunto de un status específico para el personal operativo seleccionado
        /// de acuerdo al mes y año
        /// </summary>
        /// <param name="enTiempo">Indica si se solicitan los asuntos que se entregaron en tiempo o aquellos con retrazo</param>
        /// <param name="idOperativo">Identificador del personal del cual se desean conocer sus registros</param>
        /// <param name="mes"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int GetTotalPorStatusPorMes(int enTiempo, int idOperativo, int mes, int year)
        {
            int total = 0;

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                string sqlQuery = "SELECT COUNT(EnTiempo) AS Total FROM Trabajo " +
                                  "WHERE FechaEntregaInt > 0 AND EnTiempo = @EnTiempo AND IdPerOperativo = @IdOperativo " +
                                  "AND (MONTH(FechaEntrega) = @mMes AND YEAR(FechaEntrega) = @mYear)";

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@EnTiempo", enTiempo);
                cmd.Parameters.AddWithValue("@IdOperativo", idOperativo);
                cmd.Parameters.AddWithValue("@mMes", mes);
                cmd.Parameters.AddWithValue("@mYear", year);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    total = Convert.ToInt32(reader["Total"]);
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

            return total;
        }

        public AreaStackedSeries2D GetTiemposTrbajo(PersonalCcst operativo, int monthsToShow, int enTiempo)
        {
            AreaStackedSeries2D serie = new AreaStackedSeries2D() { DisplayName = (enTiempo == 1) ? "En tiempo" : "Con retrazo" };
            //serie.Name = operativo.NombreCompleto;
            DateTime finalTime = DateTime.Now;
            DateTime initialTime = finalTime.AddMonths(-monthsToShow);

            while (initialTime <= finalTime)
            {
                serie.Points.Add(new SeriesPoint(String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(initialTime.Month), initialTime.Year),
                    this.GetTotalPorStatusPorMes(enTiempo, operativo.IdPersonal, initialTime.Month, initialTime.Year)));

                initialTime = initialTime.AddMonths(1);
            }
            return serie;
        }

        #region PaginasTotales

        //public LineSeries GetTotalPaginasTrabajadas(PersonalCcst operativo, int monthsToShow,int nda)
        //{
        //    LineSeries serie = new LineSeries();
        //    //serie.Name = operativo.NombreCompleto;
        //    DateTime finalTime = DateTime.Now;
        //    DateTime initialTime = finalTime.AddMonths(-monthsToShow);

        //    while (initialTime <= finalTime)
        //    {
        //        serie.DataPoints.Add(new CategoricalDataPoint()
        //        {
        //            Category = String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(initialTime.Month), initialTime.Year),
        //            Value = this.GetTotalPaginasPorMes(operativo.IdPersonal, initialTime.Month, initialTime.Year)
        //        });

        //        initialTime = initialTime.AddMonths(1);
        //    }
        //    return serie;
        //}

        public LineSeries2D GetTotalPaginasTrabajadas(PersonalCcst operativo, int monthsToShow)
        {
            LineSeries2D serie = new LineSeries2D() { DisplayName = operativo.NombreCompleto, MarkerVisible = true };
            //serie.Name = operativo.NombreCompleto;
            DateTime finalTime = DateTime.Now;
            DateTime initialTime = finalTime.AddMonths(-monthsToShow);

            foreach (KeyValuePair<string, int> punto in GetTotalPaginasPorMes(operativo.IdPersonal, initialTime, finalTime))
                serie.Points.Add(new SeriesPoint(punto.Key, punto.Value));

            return serie;
        }

        public List<KeyValuePair<string, int>> GetTotalPaginasPorMes(int idOperativo, DateTime inicio, DateTime fin)
        {
            List<KeyValuePair<string, int>> paginasMes = new List<KeyValuePair<string, int>>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            string inicioDate = String.Format("{0}{1}{2}", inicio.Year, inicio.Month.ToString("00"), "01");
            string finDate = String.Format("{0}{1}{2}", fin.Year, fin.Month.ToString("00"), "31");
            try
            {
                string sqlQuery = String.Format("SELECT SUM(PaginasTotales) AS Total, MONTH(fechainicio) AS mMes, YEAR(fechainicio) AS mYear " +
                                                "FROM Trabajo WHERE IdPerOperativo = @IdOperativo AND (FechaInicioInt BETWEEN {0} AND {1}) " +
                                                "GROUP BY MONTH(fechainicio), YEAR(fechainicio) ORDER BY  YEAR(fechainicio), MONTH(fechainicio)", inicioDate, finDate);

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdOperativo", idOperativo);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    paginasMes.Add(new KeyValuePair<string, int>(
                        String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader["mMes"])), Convert.ToInt32(reader["mYear"])),
                        Convert.ToInt32(reader["Total"])));
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

            return paginasMes;
        }

        public int GetPaginasRelacionadas(int idTrabajo, string tabla)
        {
            int numPaginas = 0;

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                string sqlQuery = String.Format("SELECT IdTrabajo,SUM(Paginas) AS Total FROM {0} WHERE IdTrabajo = @IdTrabajo GROUP BY IdTrabajo", tabla);

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdTrabajo", idTrabajo);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    numPaginas = Convert.ToInt32(reader["Total"]);
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

            return numPaginas;
        }

        #endregion

        #region PromedioTiempoPorActividad


        public BarSideBySideSeries3D GetTiempoPromGeneral()
        {
            BarSideBySideSeries3D serie = new BarSideBySideSeries3D();
            //serie.Name = operativo.NombreCompleto;

            foreach (KeyValuePair<string, int> punto in GetPromTiempoActs())
                serie.Points.Add(new SeriesPoint(punto.Key, punto.Value));

            return serie;
        }

        public List<KeyValuePair<string, int>> GetPromTiempoActs()
        {
            List<KeyValuePair<string, int>> paginasMes = new List<KeyValuePair<string, int>>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                string sqlQuery = "SELECT T.IdActividad, Sum(T.PaginasTotales) AS Paginas, Sum(T.TiempoTrabajoMinutos) AS TotMinutos, A.Descripcion " +
                                  "FROM Trabajo T INNER JOIN TipoActividad A ON T.IdActividad = A.IdActividad " +
                                  "WHERE T.Idactividad In (select IdActividad from TipoActividad) AND T.FechaEntregaInt > 0 " +
                                  "GROUP BY T.IdActividad, A.Descripcion";

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int paginas = Convert.ToInt32(reader["Paginas"]);
                    int minutos = Convert.ToInt32(reader["TotMinutos"]);

                    double pagsXhora = ((paginas * 60) / minutos);
                    pagsXhora = Math.Round(pagsXhora, MidpointRounding.AwayFromZero);

                    paginasMes.Add(new KeyValuePair<string, int>(reader["Descripcion"].ToString(),Convert.ToInt32(pagsXhora)));
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

            return paginasMes;
        }

        public RadarLineSeries2D GetTiempoPromedio(PersonalCcst operativo)
        {
            RadarLineSeries2D serie = new RadarLineSeries2D() { DisplayName = operativo.NombreCompleto };
            //serie.Name = operativo.NombreCompleto;

            foreach (KeyValuePair<string, int> punto in GetPromTiempoActs(operativo))
                serie.Points.Add(new SeriesPoint(punto.Key, punto.Value));

            return serie;
        }

        public List<KeyValuePair<string, int>> GetPromTiempoActs(PersonalCcst operativo)
        {
            List<KeyValuePair<string, int>> paginasMes = new List<KeyValuePair<string, int>>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                string sqlQuery = "SELECT T.IdActividad, Sum(T.PaginasTotales) AS Paginas, Sum(T.TiempoTrabajoMinutos) AS TotMinutos, A.Descripcion " +
                                  "FROM Trabajo T INNER JOIN TipoActividad A ON T.IdActividad = A.IdActividad " +
                                  "WHERE T.Idactividad In (select IdActividad from TipoActividad WHERE IdActividad <> 128) AND T.FechaEntregaInt > 0 AND IdPerOperativo = @IdOperativo  " +
                                  "GROUP BY T.IdActividad, A.Descripcion";

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdOperativo", operativo.IdPersonal);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int paginas = Convert.ToInt32(reader["Paginas"]);
                    int minutos = Convert.ToInt32(reader["TotMinutos"]);

                    double pagsXhora = ((paginas * 60) / minutos);
                    pagsXhora = Math.Round(pagsXhora, MidpointRounding.AwayFromZero);

                    paginasMes.Add(new KeyValuePair<string, int>(reader["Descripcion"].ToString(), Convert.ToInt32(pagsXhora)));
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

            return paginasMes;
        }
        
        #endregion


        #region AsuntosPaginas

        

        public List<PaginasAsuntos> GetAsuntosPaginas(string tipoPersonalColumnName, int idPersonal, int monthsToShow)
        {
            List<PaginasAsuntos> listaTotales = new List<PaginasAsuntos>();

            string fin = String.Format("{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month.ToString("00"), "31");

            string inicio = String.Format("{0}{1}{2}", DateTime.Now.AddMonths(-monthsToShow).Year, DateTime.Now.AddMonths(-monthsToShow).Month.ToString("00"), "01");

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                string sqlQuery = String.Format("SELECT COUNT({0}) AS Asuntos,SUM(PaginasTotales) AS Paginas, Month(FechaInicio) AS mMes,Year(FechaInicio) AS mYear FROM Trabajo " +
                                  "WHERE {0} = @IdPersonal and FechaInicioInt BETWEEN @InicioF AND @FinF GROUP BY Month(FechaInicio),Year(FechaInicio) ORDER BY Year(FechaInicio),Month(FechaInicio)", tipoPersonalColumnName);

                connection.Open();

                cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdPersonal", idPersonal);
                cmd.Parameters.AddWithValue("@InicioF", inicio);
                cmd.Parameters.AddWithValue("@FinF", fin);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PaginasAsuntos asunto = new PaginasAsuntos()
                    {
                        Mes = String.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(reader["mMes"])), Convert.ToInt32(reader["mYear"])),
                        NumeroAsuntos = Convert.ToInt32(reader["Asuntos"]),
                        NumeroPaginas = Convert.ToInt32(reader["Paginas"])
                    };

                    listaTotales.Add(asunto);
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

            return listaTotales;
        }


        #endregion


    }
}