﻿using System;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Dto;
using ScjnUtilities;
using System.Configuration;
using ControlDeTiempos.Singleton;

namespace ControlDeTiempos.Model
{
    public class PersonalModel
    {
        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public ObservableCollection<PersonalCcst> GetPersonal()
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal ORDER BY IdPersonal", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonalCcst personal = new PersonalCcst()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"], reader["Apellidos"]),
                        TipoPersonal = Convert.ToInt32(reader["TipoPersonal"]),
                        Seccion = Convert.ToInt32(reader["Seccion"]),
                        TiempoNoLaborableDiario = Convert.ToInt32(reader["TiempoNoLaboral"])
                    };
                    listaPersonal.Add(personal);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }

        public ObservableCollection<PersonalCcst> GetPersonal(int idTipoPersonal)
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal WHERE TipoPersonal = @TipoPersonal ORDER BY IdPersonal", connection);
                cmd.Parameters.AddWithValue("@TipoPersonal", idTipoPersonal);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonalCcst personal = new PersonalCcst()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"], reader["Apellidos"]),
                        TipoPersonal = Convert.ToInt32(reader["TipoPersonal"]),
                        Seccion = Convert.ToInt32(reader["Seccion"])
                    };
                    listaPersonal.Add(personal);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }

        public ObservableCollection<PersonalCcst> GetPersonalForFilter()
        {
            ObservableCollection<PersonalCcst> personal = new ObservableCollection<PersonalCcst>();

            PersonalCcst abogados = new PersonalCcst()
            {
                NombreCompleto = "Abogados responsables",
                IdPersonal = 10000,
                Child = GetPersonal(1)
            };

            PersonalCcst operativos = new PersonalCcst()
            {
                NombreCompleto = "Personal operativo",
                IdPersonal = 10001,
                Child = GetPersonal(3)
            };

            personal.Add(abogados);
            personal.Add(operativos);

            return personal;
        }

        public ObservableCollection<PersonalCcst> GetPersonalAsignado()
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal WHERE TipoPersonal = 3 AND " +
                                       " IdPersonal IN (SELECT IdPerOperativo FROM Trabajo GROUP BY IdPerOperativo)", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonalCcst personal = new PersonalCcst()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"], reader["Apellidos"]),
                        TipoPersonal = Convert.ToInt32(reader["TipoPersonal"]),
                        Seccion = Convert.ToInt32(reader["Seccion"])
                    };
                    listaPersonal.Add(personal);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }

        #region Sugerencia

        /// <summary>
        /// Indica el orden sugerido para la asignación de personal de colegiados
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<PersonalCcst> GetPersonalSugerido()
        {
            ObservableCollection<PersonalCcst> listaPersonal = this.GetPersonalSinAsignaciones();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                string sqlQuery = "SELECT MAX(t.fechainicio), t.idperoperativo FROM trabajo t where t.idperoperativo " +
                                  "IN(SELECT  p.idpersonal FROM Personal p WHERE p.tipopersonal = 3 AND p.seccion = 2) GROUP BY  t.idperoperativo " +
                                  " ORDER BY Max(t.fechaInicio) ";

                cmd = new OleDbCommand(sqlQuery, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaPersonal.Add(PersonalSingleton.Personal.SingleOrDefault(x => x.IdPersonal == Convert.ToInt32(reader["IdPerOperativo"])));
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }

        private ObservableCollection<PersonalCcst> GetPersonalSinAsignaciones()
        {
            ObservableCollection<PersonalCcst> listaPersonal = new ObservableCollection<PersonalCcst>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal WHERE TipoPersonal = 3 AND Seccion = 2 AND " +
                                       " IdPersonal NOT IN (SELECT IdPerOperativo FROM Trabajo GROUP BY IdPerOperativo)", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonalCcst personal = new PersonalCcst()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        NombreCompleto = String.Format("{0} {1}", reader["Nombre"], reader["Apellidos"]),
                        TipoPersonal = Convert.ToInt32(reader["TipoPersonal"]),
                        Seccion = Convert.ToInt32(reader["Seccion"])
                    };
                    listaPersonal.Add(personal);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }

        public ObservableCollection<Asignacion> GetPersonalSugerido1()
        {
            ObservableCollection<Asignacion> listaPersonal = this.GetPersonalSinAsignaciones1();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                string sqlQuery = "SELECT Tr.IdPerOperativo, MAX(Tr.FechaInicio) AS Ultima," +
                                  "(SELECT MAX(FechaIndicada) FROM Trabajo T WHERE T.FechaEntregaInt = 0 AND T.IdPerOperativo = Tr.IdPerOperativo) AS Siguiente, " +
                                  "(SELECT COUNT(T.IdPerOperativo) FROM Trabajo T WHERE T.FechaEntregaInt = 0 AND T.IdPerOperativo = Tr.IdPerOperativo) AS APendientes, " +
                                  "(SELECT SUM(T.PaginasTotales) FROM Trabajo T WHERE T.FechaEntregaInt = 0 AND T.IdPerOperativo = Tr.IdPerOperativo) AS HPendientes " +
                                  "FROM Trabajo Tr where IdPerOperativo > 0 GROUP BY Tr.IdPerOperativo";

                cmd = new OleDbCommand(sqlQuery, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Asignacion asignacion = new Asignacion();
                    
                        asignacion.IdPersonal = Convert.ToInt32(reader["IdPerOperativo"]);
                        asignacion.UltimaAsignacion = DateTimeUtilities.GetDateFromReader(reader,"Ultima");
                        asignacion.UltimaEntrega = DateTimeUtilities.GetDateFromReader(reader,"Siguiente");
                        asignacion.AsuntosPendientes = reader["APendientes"] as int? ?? 0;
                        asignacion.HojasPendientes = Convert.ToInt32(reader["HPendientes"] as double? ?? 0);
                    

                    listaPersonal.Add(asignacion);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return new ObservableCollection<Asignacion>(from n in listaPersonal
                                                        orderby n.HojasPendientes, n.AsuntosPendientes, n.UltimaAsignacion
                                                        select n);
        }

        private ObservableCollection<Asignacion> GetPersonalSinAsignaciones1()
        {
            ObservableCollection<Asignacion> listaPersonal = new ObservableCollection<Asignacion>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Personal WHERE TipoPersonal = 3 AND Seccion = 2 AND " +
                                       " IdPersonal NOT IN (SELECT IdPerOperativo FROM Trabajo GROUP BY IdPerOperativo)", connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Asignacion personal = new Asignacion()
                    {
                        IdPersonal = Convert.ToInt32(reader["IdPersonal"]),
                        UltimaAsignacion = null,
                        UltimaEntrega = null,
                        AsuntosPendientes = 0,
                        HojasPendientes = 0
                    };
                    listaPersonal.Add(personal);
                }

                reader.Close();
                cmd.Dispose();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PersonalCcst", "ControlDeTiempos");
            }
            finally
            {
                connection.Close();
            }

            return listaPersonal;
        }
        
        #endregion
    }
}