﻿#pragma checksum "..\..\..\Graphs\NumAsuntoGraph.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7DD03997E64E99DD82D501513C31D5E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// NumAsuntoGraph
    /// </summary>
    public partial class NumAsuntoGraph : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Graphs\NumAsuntoGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadRadioButton Rad3M;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Graphs\NumAsuntoGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadRadioButton Rad6M;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Graphs\NumAsuntoGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadRadioButton Rad12M;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Graphs\NumAsuntoGraph.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Telerik.Windows.Controls.RadChart RchNumAsun;
        
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
            System.Uri resourceLocater = new System.Uri("/ControlDeTiempos;component/graphs/numasuntograph.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Graphs\NumAsuntoGraph.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 10 "..\..\..\Graphs\NumAsuntoGraph.xaml"
            ((ControlDeTiempos.Graphs.NumAsuntoGraph)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Rad3M = ((Telerik.Windows.Controls.RadRadioButton)(target));
            
            #line 25 "..\..\..\Graphs\NumAsuntoGraph.xaml"
            this.Rad3M.Checked += new System.Windows.RoutedEventHandler(this.Rad3M_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Rad6M = ((Telerik.Windows.Controls.RadRadioButton)(target));
            
            #line 34 "..\..\..\Graphs\NumAsuntoGraph.xaml"
            this.Rad6M.Checked += new System.Windows.RoutedEventHandler(this.Rad6M_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Rad12M = ((Telerik.Windows.Controls.RadRadioButton)(target));
            
            #line 43 "..\..\..\Graphs\NumAsuntoGraph.xaml"
            this.Rad12M.Checked += new System.Windows.RoutedEventHandler(this.Rad12M_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RchNumAsun = ((Telerik.Windows.Controls.RadChart)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

