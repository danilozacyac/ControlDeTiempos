using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ControlDeTiempos.Dto;
using ControlDeTiempos.Model;
using ControlDeTiempos.Singleton;
using DevExpress.Xpf.Charts;
using System.Windows.Media.Animation;
using System.Windows.Input;

namespace ControlDeTiempos.Graphs
{
    /// <summary>
    /// Interaction logic for ActiOper.xaml
    /// </summary>
    public partial class ActiOper
    {
        PersonalCcst selectedPersonal;

        const int ClickDelta = 200;

        DateTime mouseDownTime;
        bool rotate;
        Point startPosition;

        public ActiOper()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cbxoperativos.DataContext = PersonalSingleton.Personal.Where(n => n.TipoPersonal == 3);

            Cbxoperativos.SelectedIndex = 2;
           
        }

        private void Cbxoperativos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPersonal = Cbxoperativos.SelectedItem as PersonalCcst;

            List<ActOperativos> distr = new ActividadesModel().GetActividadesByOperativo(selectedPersonal.IdPersonal);

            this.DataContext = distr;

            while (DistrActsSerie.Points.Count() > 0)
                DistrActsSerie.Points.RemoveAt(0);



            foreach (ActOperativos actividad in distr)
                DistrActsSerie.Points.Add(new SeriesPoint(actividad.Etiqueta, actividad.Valor));

            chart.Animate();

            OperStatus.Operativo = selectedPersonal;
            AsunPag.Operativo = selectedPersonal;
            Promedios.Operativo = selectedPersonal;
        }

        bool IsClick(DateTime mouseUpTime)
        {
            return (mouseUpTime - mouseDownTime).TotalMilliseconds < ClickDelta;
        }

        double CalcAngle(Point p1, Point p2)
        {
            Point center = new Point(chart.Diagram.ActualWidth / 2, chart.ActualHeight / 2);
            Point relativeP1 = new Point(p1.X - center.X, p1.Y - center.Y);
            Point relativeP2 = new Point(p2.X - center.X, p2.Y - center.Y);
            double angleP1Radian = Math.Atan2(relativeP1.X, relativeP1.Y);
            double angleP2Radian = Math.Atan2(relativeP2.X, relativeP2.Y);
            double angle = (angleP2Radian - angleP1Radian) * 180 / (Math.PI * 2);
            if (angle > 90)
                angle = 180 - angle;
            else if (angle < -90)
                angle = 180 + angle;
            return angle;
        }
        void ChartMouseUp(object sender, MouseButtonEventArgs e)
        {
            ChartHitInfo hitInfo = chart.CalcHitInfo(e.GetPosition(chart));
            rotate = false;
            if (hitInfo == null || hitInfo.SeriesPoint == null || !IsClick(DateTime.Now))
                return;
            double distance = PieSeries.GetExplodedDistance(hitInfo.SeriesPoint);
            Storyboard storyBoard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300));
            animation.To = distance > 0 ? 0 : 0.3;
            storyBoard.Children.Add(animation);
            Storyboard.SetTarget(animation, hitInfo.SeriesPoint);
            Storyboard.SetTargetProperty(animation, new PropertyPath(PieSeries.ExplodedDistanceProperty));
            storyBoard.Begin();
        }
        void ChartMouseDown(object sender, MouseButtonEventArgs e)
        {
            mouseDownTime = DateTime.Now;
            Point position = e.GetPosition(chart);
            ChartHitInfo hitInfo = chart.CalcHitInfo(position);
            if (hitInfo != null && hitInfo.SeriesPoint != null)
            {
                rotate = true;
                startPosition = position;
            }
        }
        void ChartMouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(chart);
            ChartHitInfo hitInfo = chart.CalcHitInfo(position);
            if (hitInfo == null)
                return;
            if (rotate && !IsClick(DateTime.Now))
            {
                PieSeries2D series = chart.Diagram.Series[0] as PieSeries2D;
                double angleDelta = CalcAngle(startPosition, position);
                
                startPosition = position;
            }
        }
        void ChartsDemoModule_ModuleAppear(object sender, RoutedEventArgs e)
        {
            
        }
        
        void ChartQueryChartCursor(object sender, QueryChartCursorEventArgs e)
        {
            ChartHitInfo hitInfo = chart.CalcHitInfo(e.Position);
            if (hitInfo != null && hitInfo.SeriesPoint != null)
                e.Cursor = Cursors.Hand;
        }
    }
}
