using ControlDeTiempos.Graphs;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTiempos.Model
{
    public class ActividadesModel
    {

        private readonly string connectionStr = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public List<KeyValuePair<string, int>> GetActividadesByOperativo(int idOperativo)
        {
            int legislacion = 0, estandarizacion = 0, cotejo = 0, correcciones = 0, octava = 0, subvinculo = 0, otros = 0;

            List<KeyValuePair<string, int>> listadoActs = new List<KeyValuePair<string, int>>();

            OleDbConnection connection = new OleDbConnection(connectionStr);
            OleDbCommand cmd;
            OleDbDataReader reader;

            try
            {
                connection.Open();

                cmd = new OleDbCommand("SELECT * FROM Tesis WHERE IdPerOperativo = @IdPerOperativo", connection);
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

                
                listadoActs.Add(new KeyValuePair<string,int>("Legislación", legislacion));
                listadoActs.Add(new KeyValuePair<string, int>("Estandarización", estandarizacion));
                listadoActs.Add(new KeyValuePair<string, int>("Cotejo", cotejo));
                listadoActs.Add(new KeyValuePair<string, int>("Correcciones", correcciones));
                listadoActs.Add(new KeyValuePair<string, int>("Octava Parte", octava));
                listadoActs.Add(new KeyValuePair<string, int>("Subvínculo Precedentes", subvinculo));
                listadoActs.Add(new KeyValuePair<string, int>("Otro", otros));

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
