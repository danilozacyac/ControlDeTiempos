using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using ControlDeTiempos.Graphs;
using ScjnUtilities;

namespace ControlDeTiempos.Model
{
    public class ActividadesModel
    {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public List<ActOperativos> GetActividadesByOperativo(int idOperativo)
        {
            int legislacion = 0, estandarizacion = 0, cotejo = 0, correcciones = 0, octava = 0, subvinculo = 0, otros = 0;

            List<ActOperativos> listadoActs = new List<ActOperativos>();

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
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Legislación", Valor = legislacion });
                if (estandarizacion > 0)
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Estandarización", Valor = estandarizacion });
                if (cotejo > 0)
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Cotejo", Valor = cotejo });
                if (correcciones > 0)
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Correcciones", Valor = correcciones });
                if (octava > 0)
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Octava Parte", Valor = octava });
                if (subvinculo > 0)
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Subvínculo Precedentes", Valor = subvinculo });
                if (otros > 0)
                    listadoActs.Add(new ActOperativos() { Etiqueta = "Otro", Valor = otros });

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
