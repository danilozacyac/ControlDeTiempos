   M S B A M L   `   `   `  ����K  GControlDeTiempos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ControlDeTiempos.Graphs.Operativos"ControlDeTiempos.Graphs.Operativos  5      *    $ControlDeTiempos.Graphs.PorOperativo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      G
Operativos0clr-namespace:ControlDeTiempos.Graphs.Operativos     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��300��5      $	��300��5      $��Información��5      )  #Telerik.Windows.Controls.WindowBase    WindowState$  	Maximized=�5
      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   *  $Telerik.Windows.Controls.RadComboBox  -   5          Name$ Cbxoperativos��5      $	��211��5      $��	88,18,0,0q�5      $
��Left=�5      $	��Top=�5       �� DisplayMemberPath$ NombreCompleto��5       �� SelectedValuePath$ 
IdPersonal��5      ��5      �� 5      �� 5   
   $��	21,18,0,0q�6   $
��Left=�5       $	��Top=�5!      $��	Personal:��5"      $
��Bold"�5#      5   /ControlDeTiempos.Graphs.Operativos.Distribucion  5$   
   -   5          Name$ Distribucion��5$   "   $��1��5%   &   $
��Left=�5&   &   $	��Top=�5'   &   7   1ControlDeTiempos.Graphs.Operativos.AsuntosPaginas  5(   
   -   5          Name$ Asuntos��5(   $   $��1��5)   $   $��1��5*   $   $
��Left=�5+   $   $	��Top=�5,   $   9   3ControlDeTiempos.Graphs.Operativos.EnTiempoNoTiempo  5.   
   -   5          Name$ Status��5.   &   $��2��5/   &   $
��Left=�50   &   $	��Top=�51   &   7   1ControlDeTiempos.Graphs.Operativos.AvgActividades  52   
   -   5        	  Name$	 Promedio��52   $   $��2��53   $   $��1��54   $   $
��Left=�55   $   $	��Top=�56   $   58      59      