   M S B A M L   `   `   `  ����  ControlDeTiempos    ControlDeTiempos.ErrorWin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��600��5      $	��300��5      $��Ventana de Errores��5      (  "Telerik.Windows.Controls.RadWindow    WindowStartupLocation$  CenterScreen=�5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��	10,10,0,0q�6   $
��Left=�5      $	��Top=�5      $��Listado de errores:��5      $��14(�5      $
��Bold"�5      )  #Telerik.Windows.Controls.RadListBox  5   
   -   5          Name$ RLstErrores��5      $��10,50,10,50q�5      $��Stretch=�5      $��Stretch=�5       �� DisplayMemberPath$ Descripcion��5      ��5      �� 5      �� 5   
   -   5         ��Name$ 
BtnAgregar��5      $��80��5      $��
10,219,0,0q�5      $
��Left=�5      $	��Top=�5       $��Agregar��5"         
BlueButton#��[  5#      �� 5$   
   -   5        $ BtnModificar��5$      $��80��5%      $��
95,219,0,0q�5&      $
��Left=�5'      $	��Top=�5(      $��Editar��5*      #��[  5+      �� 5,   
   -   5        $ BtnEliminar��5,      $��80��5-      $��180,219,0,0q�5.      $
��Left=�5/      $	��Top=�50      $��Eliminar��52      #��[  53      �� 55   
   $��1��6   $��	10,10,0,0q�56      $
��Left=�57      $	��Top=�58      $��Descripción:��59      $��14(�5:      $
��Bold"�5;      �� 5<   
   -   5         ��Name$ TxtDescripcion��5<      $��1��5=      $	��270��5>      $��26��5?      $��	10,44,0,0q�5@      $
��Left=�5A      $	��Top=�5B      {�.   �� TextWrapping$
 Wrap=�5E      ��5D      �� *Descripcion+5E      �� 5F   
   $��1��6   $��	10,75,0,0q�5G      $
��Left=�5H      $	��Top=�5I      $��Archivo:��5J      $��14(�5K      $
��Bold"�5L      �� 5M   
   -   5        $ 
TxtArchivo��5M      $��1��5N      $	��190��5O      $��23��5P      $��
10,104,0,0q�5Q      $
��Left=�5R      $	��Top=�5S      {�.  ��5U      �� *NombreArchivo+�� 5V   
   -   5        $ BtnVerArchivo��5V      $��1��5W      $��75��5X      $��205,104,0,0q�5Y      $
��Left=�5Z      $	��Top=�5[      $	��Ver��5]      #��[  5^      �� 5_   
   $��1��6   $��
10,144,0,0q�5`      $
��Left=�5a      $	��Top=�5b      $��Observaciones:��5c      $��14(�5d      $
��Bold"�5e      �� 5f   
   -	   5        $ TxtObservaciones��5f      $��1��5g      $��10,170,10,20q�5h      $��Stretch=�5i      $��Stretch=�5j      {�.  $
 Wrap=�5m      ��5l      �� *Comentarios+5m      5o      5p      