using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Graphs;
using ScjnUtilities;
using ControlDeTiempos.Dto;

namespace ControlDeTiempos.Model
{
    public class ActividadesModel
    {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public List<Graficas> GetActividadesByOperativo(int idOperativo)
        {
            int legislacion = 0, estandarizacion = 0, cotejo = 0, correcciones = 0, octava = 0, subvinculo = 0, otros = 0;

            List<Graficas> listadoActs = new List<Graficas>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM trabajo WHERE IdPerOperativo = @IdPerOperativo", connection);
                cmd.Parameters.AddWithValue("@IdPerOperativo", idOperativo);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<int> acts = NumericUtilities.GetDecimalsInBinary(Convert.ToInt32(reader["IdActividad"]));

                    if (acts.Contains(1))
                        legislacion += 1;
                    if (acts.Contains(2))
                        estandarizacion += 1;
                    if (acts.Contains(4))
                        cotejo += 1;
                    if (acts.Contains(8))
                        correcciones += 1;
                    if (acts.Contains(16))
                        octava += 1;
                    if (acts.Contains(32))
                        subvinculo += 1;
                    if (acts.Contains(64))
                        otros += 1;

                }

                if (legislacion > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Legislación", NumeroAsuntos = legislacion });
                if (estandarizacion > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Estandarización", NumeroAsuntos = estandarizacion });
                if (cotejo > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Cotejo", NumeroAsuntos = cotejo });
                if (correcciones > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Correcciones", NumeroAsuntos = correcciones });
                if (octava > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Octava Parte", NumeroAsuntos = octava });
                if (subvinculo > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Subvínculo Precedentes", NumeroAsuntos = subvinculo });
                if (otros > 0)
                    listadoActs.Add(new Graficas() { Actividad = "Otro", NumeroAsuntos = otros });

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

            return listadoActs;
        }


    }
}
