﻿#pragma checksum "..\..\..\Graphs\PorOperativo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E61B4A3B2059C9FBF24AE745F621C05A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ControlDeTiempos.Graphs.Operativos;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Animation;
using Telerik.Windows.Controls.Carousel;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Charting;
using Telerik.Windows.Controls.Docking;
using Telerik.Windows.Controls.DragDrop;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls.Legend;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Controls.RibbonView;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.Controls.TransitionEffects;
using Telerik.Windows.Controls.TreeListView;
using Telerik.Windows.Controls.TreeView;
using Telerik.Windows.Data;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;
using Telerik.Windows.Input.Touch;
using Telerik.Windows.Shapes;


namespace ControlDeTiempos.Graphs {
    
    
    /// <summary>
    /// PorOperativo
    /// </summary>
    public partial class PorOperativo : Telerik.Windows.Controls.RadWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Graphs\PorOperativo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadComboBox Cbxoperativos;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Graphs\PorOperativo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlDeTiempos.Graphs.Operativos.Distribucion Distribucion;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Graphs\PorOperativo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlDeTiempos.Graphs.Operativos.AsuntosPaginas Asuntos;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Graphs\PorOperativo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlDeTiempos.Graphs.Operativos.EnTiempoNoTiempo Status;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Graphs\PorOperativo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ControlDeTiempos.Graphs.Operativos.AvgActividades Promedio;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ControlDeTiempos;component/graphs/poroperativo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Graphs\PorOperativo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Graphs\PorOperativo.xaml"
            ((ControlDeTiempos.Graphs.PorOperativo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.RadWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Cbxoperativos = ((Telerik.Windows.Controls.RadComboBox)(target));
            
            #line 30 "..\..\..\Graphs\PorOperativo.xaml"
            this.Cbxoperativos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Cbxoperativos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Distribucion = ((ControlDeTiempos.Graphs.Operativos.Distribucion)(target));
            return;
            case 4:
            this.Asuntos = ((ControlDeTiempos.Graphs.Operativos.AsuntosPaginas)(target));
            return;
            case 5:
            this.Status = ((ControlDeTiempos.Graphs.Operativos.EnTiempoNoTiempo)(target));
            return;
            case 6:
            this.Promedio = ((ControlDeTiempos.Graphs.Operativos.AvgActividades)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

