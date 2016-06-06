using ControlDeTiempos.Dto;
using ControlDeTiempos.Singleton;
using Microsoft.Office.Interop.Word;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeTiempos.Reportes
{
    public class WordReport
    {
        Microsoft.Office.Interop.Word.Application oWord;
        Microsoft.Office.Interop.Word.Document aDoc;
        object oMissing = System.Reflection.Missing.Value;
        object oEndOfDoc = "\\endofdoc";

        public void HojaDeControl(TrabajoAsignado trabajo)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            aDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            aDoc.PageSetup.Orientation = WdOrientation.wdOrientPortrait;


            try
            {
                //Insert a paragraph at the beginning of the document.
                Microsoft.Office.Interop.Word.Paragraph oPara1;
                oPara1 = aDoc.Content.Paragraphs.Add(ref oMissing);
                //oPara1.Range.Text = "SUPREMA CORTE DE JUSTICIA DE LA NACIÓN";
                //oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 16;
                oPara1.Range.Font.Name = "Arial";
                oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
                oPara1.Range.Text = DateTime.Now.ToLongDateString();
                oPara1.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                this.ParagraphAfter(oPara1, 2);


                Range wrdRng = aDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

                Table oTable = aDoc.Tables.Add(wrdRng, 13, 2, ref oMissing, ref oMissing);
                oTable.Rows[1].HeadingFormat = -1; //Repite el encabezado de la tabla en cada hoja
                oTable.Range.ParagraphFormat.SpaceAfter = 6;
                oTable.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oTable.Range.Font.Size = 14;
                oTable.Range.Font.Name = "Arial";
                oTable.Range.Font.Bold = 0;
                oTable.Borders.Enable = 0;

                oTable.Columns[1].SetWidth(200, WdRulerStyle.wdAdjustSameWidth);
                oTable.Columns[2].SetWidth(200, WdRulerStyle.wdAdjustSameWidth);
                oTable.Cell(1, 1).Range.Text = "Abogado responsable:";
                oTable.Cell(1, 2).Range.Text = PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == trabajo.IdAbogado).NombreCompleto;
                oTable.Cell(2, 1).Range.Text = "Personal operativo:";
                oTable.Cell(2, 2).Range.Text = PersonalSingleton.Personal.SingleOrDefault(n => n.IdPersonal == trabajo.IdOperativo).NombreCompleto; ;
                oTable.Cell(3, 1).Range.Text = "Tipo de Asunto:";
                oTable.Cell(3, 2).Range.Text = TipoAsuntoSingleton.TipoAsunto.SingleOrDefault(n => n.IdTipoAsunto == trabajo.IdTipoAsunto).Descripcion;
                oTable.Cell(4, 1).Range.Text = "Número de expediente:";
                oTable.Cell(4, 2).Range.Text = String.Format("{0}/{1}",trabajo.NumExpediente,trabajo.AnioExpediente);
                oTable.Cell(5, 1).Range.Text = "Páginas:";
                oTable.Cell(5, 2).Range.Text = trabajo.PaginasEjecutoria.ToString();
                oTable.Cell(6, 1).Range.Text = "Trabajo";
                oTable.Cell(6, 2).Range.Text = this.GetActividadesRealizadas(trabajo.IdActividad);
                oTable.Cell(7, 1).Range.Text = "Particularidad";
                oTable.Cell(7, 2).Range.Text = trabajo.Particularidades;
                oTable.Cell(8, 1).Range.Text = "Prioridad";
                oTable.Cell(8, 2).Range.Text = PrioridadSingleton.Prioridades.SingleOrDefault(n => n.IdPrioridad == trabajo.IdPrioridad).Prioridad;
                oTable.Cell(9, 1).Range.Text = "Fecha y hora de inicio:";
                oTable.Cell(9, 2).Range.Text = trabajo.FechaInicio.ToString();
                oTable.Cell(10, 1).Range.Text = "Fecha y hora indicada:";
                oTable.Cell(10, 2).Range.Text = trabajo.FechaIndicada.ToString();
                oTable.Cell(11, 1).Range.Text = "Fecha y hora de entrega:";
                oTable.Cell(11, 2).Range.Text = " ";
                oTable.Cell(12, 1).Range.Text = "\n\n ____________________";
                oTable.Cell(12, 2).Range.Text = "\n\n ____________________";
                oTable.Cell(13, 1).Range.Text = "Firma abogado";
                oTable.Cell(13, 2).Range.Text = "Firma operativo";

                for (int i = 0; i < 13; i++)
                {
                    oTable.Cell(i, 1).Range.Font.Bold = 1;
                    oTable.Cell(i, 1).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
                oTable.Cell(13, 2).Range.Font.Bold = 1;
                //oWord.ActiveDocument.SaveAs(filePath);
                //oWord.ActiveDocument.Saved = true;
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,WordReports", "ControlDeTiempos");
            }
            finally
            {
                oWord.Visible = true;
                //oDoc.Close();

            }
        }


        private void ParagraphAfter(Paragraph oPara, int cuantos)
        {
            while (cuantos > 0)
            {
                oPara.Range.InsertParagraphAfter();
                cuantos--;
            }
        }

        private string GetActividadesRealizadas(int idActividad)
        {
            List<int> acts = NumericUtilities.GetDecimalsInBinary(idActividad);

            List<string> listaActs = new List<string>();

            foreach(Actividades actividad in ActividadesSingleton.Actividades)
                if(acts.Contains(actividad.IdActividad))
                    listaActs.Add(actividad.Actividad);

            return String.Join(", ", listaActs);
        }

    }
}
