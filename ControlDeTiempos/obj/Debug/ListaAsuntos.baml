   M S B A M L   `   `   `  ����K  GControlDeTiempos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ControlDeTiemposControlDeTiempos  5      G(clr-namespace:ControlDeTiempos.ConverterControlDeTiempos.Converter  5      #    ControlDeTiempos.ListaAsuntos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7CustomColumnclr-namespace:ControlDeTiempos     5      >	converter(clr-namespace:ControlDeTiempos.Converter     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��900��5      $	��300��5      $�� ��5	      )  #Telerik.Windows.Controls.WindowBase    WindowState$  	Maximized=�5       � 	Resources 5      2   ,ControlDeTiempos.Converter.PersonalConverter   persConv7   1ControlDeTiempos.Converter.TipoDocumentoConverter  	tipoDConv4   .ControlDeTiempos.Converter.TipoAsuntoConverter  	tipoAConv3   -ControlDeTiempos.Converter.PrioridadConverter  	priorConv1   +ControlDeTiempos.Converter.ATiempoConverter  
tiempoConv��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6&     5   
   6+     5   
   6(     5   
   6'     5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   ,  &Telerik.Windows.Controls.RadRibbonView  $	��Top=�6       ApplicationName$# Listado de asuntos trabajados��68   .@�5      +  %Telerik.Windows.Controls.RadRibbonTab  $��General��6#   .@�5      -	  'Telerik.Windows.Controls.RadRibbonGroup	  $��Acciones��6)   .@�5      .
  (Telerik.Windows.Controls.RadRibbonButton
  -   5         
 Name$ RBtnVerTrabajo��5   .   $��Ver información��5   .    
  
LargeImage$$ Resources/1425495863_notes.png��5   .    
  Size$ Large=�5    .   
  5!      -   5        $ RBtnAgregarTrabajo��5!   .   $��Agregar��5#   .   $( "Resources/1425495838_add-notes.png��5$   .   $ Large=�5%   .   
  5&      -   5        $ RBtnEditarTrabajo��5&   .   $��Editar��5(   .   $) #Resources/1425495821_edit-notes.png��5)   .   $ Large=�5*   .   
  5+      -   5        $ RBtnEliminarTrabajo��5+   .   $��Eliminar��5,   .   {�.  $+ %Resources/1425495925_delete-notes.png��5.   .   $ Large=�5/   .   
  50      -   5        $ RBtnEntregar��50   .   $��Entregar��52   .   {�. $ Resources/clock_128.png��54   .   $ Large=�55   .   
  56      -   5        $ RBtnHojaControl��56   .   $��Hoja de control��58   .   {�. $  Resources/printer_blue.png��5:   .   $ Large=�5;   .   5<      	  5=      $��Graficas��6)   .@�5>      
  -   5        $ RBtnGraficas��5>   .   $��Reporte��5@   .   {�. $  Resources/printer_blue.png��5B   .   $ Large=�5C   .   5D      5E      5F      *  $Telerik.Windows.Controls.RadGridView  5G   
   -	   5          Name$ GPorTrabajar��5G      $��2��5H      $��Stretch=�5I      $��Stretch=�5J      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  	   
IsReadOnly	 . 
   RowIndicatorVisibility$
 	Collapsed=�5N         ShowGroupPanel .  * 
 $Telerik.Windows.Controls.DataControl   ItemsSource 5M      ��    Columns 5Q      %   ControlDeTiempos.MyColumnNumber  5R      -  'Telerik.Windows.Controls.GridViewColumn   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 60 6.     ColumnaNumerica   	CellStyle# [ 5S   .      Header$ #��5T   .      HeaderTextAlignment$ Center=�5U   .      TextAlignment$ Center=�5V   .   1  +Telerik.Windows.Controls.GridViewDataColumn  5W      $	 150 6-   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Tipo de Asunto��5Z   -   $ Center=�5[   -      IsFilterable .     DataMemberBinding 5X   -   �� *IdTipoAsunto+ �� 	Converter# [ 5\   -     5]      $	 100 6-   $ 
Núm. Exp.��5_   -   $ Center=�5`   -   $ Center=�5a   -    5^   -   �� *NumExpediente+5a   -     5b      $	 120 6-   $
 Año��5d   -   $ Center=�5e   -   $ Center=�5f   -    5c   -   �� *AnioExpediente+5f   -     5g      $	 120 6-   $ Abogado��5j   -      ShowFieldFilters .   5h   -   �� *	IdAbogado+# [  5k   -     5l      $	 130 6-   $ P. Operativo��5o   -    .   5m   -   �� *IdOperativo+# [  5p   -     5q      $	 120 6-   $ 	Documento��5t   -    .   5r   -   �� *TipoDocumento+# [ 5u   -     5v      $
 Auto 6-      DataFormatString$  {0:dd/MM/yyyy hh:mm}��5w   -   $ 	F. Inicio��5y   -    .   5x   -   �� *FechaInicio+5z   -     5{      $
 Auto 6-   $  {0:dd/MM/yyyy hh:mm}��5|   -   $ F. Indicada��5~   -    .   5}   -   �� *FechaIndicada+5   -     5�      $
 Auto 6-      MinWidth$	 120Q�5�   -   $  {0:dd/MM/yyyy hh:mm}��5�   -   $ 
F. Entrega��5�   -    .   5�   -   �� *FechaEntrega+5�   -   2  ,Telerik.Windows.Controls.GridViewImageColumn  5�      $ 	En tiempo��5�   .      ImageStretch$
 None=�5�   .    5�   .   �� *
EnTiempo+# [ 5�   .      RowStyle 5�      �� 5�       �� 
TargetType3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5�      ��  �� Property � �� �� Value 63   �� *IdPrioridad+# [ 5�      5�      5�      5�      