   M S B A M L   `   `   `  ����K  GControlDeTiempos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ControlDeTiemposControlDeTiempos  5      G(clr-namespace:ControlDeTiempos.ConverterControlDeTiempos.Converter  5      )    #ControlDeTiempos.Controles.ListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7CustomColumnclr-namespace:ControlDeTiempos     5      >	converter(clr-namespace:ControlDeTiempos.Converter     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5          � 	Resources  5      2   ,ControlDeTiempos.Converter.PersonalConverter   persConv7   1ControlDeTiempos.Converter.TipoDocumentoConverter  	tipoDConv4   .ControlDeTiempos.Converter.TipoAsuntoConverter  	tipoAConv3   -ControlDeTiempos.Converter.PrioridadConverter  	priorConv1   +ControlDeTiempos.Converter.ATiempoConverter  
tiempoConv��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6&     5   
   6+     5   
   6(     5   
   6'     5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   *  $Telerik.Windows.Controls.RadGridView  -   5          Name$ GPorTrabajar��5      $��2��5      $��Stretch=�5      $��Stretch=�5      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     
IsReadOnly .    RowIndicatorVisibility$ 	Collapsed=�5!         ShowGroupPanel .  * 
 $Telerik.Windows.Controls.DataControl   ItemsSource 5       ��    Columns 5$      %	   ControlDeTiempos.MyColumnNumber	  5%      -
  'Telerik.Windows.Controls.GridViewColumn	 
  Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 60 6.     ColumnaNumerica
 
  	CellStyle#
 [ 5&   .    
  Header$ #��5'   .    
  HeaderTextAlignment$ Center=�5(   .    
  TextAlignment$ Center=�5)   .   1  +Telerik.Windows.Controls.GridViewDataColumn  5*      $		 150 6-   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Tipo de Asunto��5-   -   $ Center=�5.   -    
  IsFilterable .     DataMemberBinding 5+   -   �� *IdTipoAsunto+ �� 	Converter# [ 5/   -     50      $		 100 6-   $ 
Núm. Exp.��52   -   $ Center=�53   -   $ Center=�54   -    51   -   �� *NumExpediente+54   -     55      $		 120 6-   $
 Año��57   -   $ Center=�58   -   $ Center=�59   -    56   -   �� *AnioExpediente+59   -     5:      $		 120 6-   $ Abogado��5=   -    
  ShowFieldFilters .   5;   -   �� *	IdAbogado+# [  5>   -     5?      $		 130 6-   $ P. Operativo��5B   -    .   5@   -   �� *IdOperativo+# [  5C   -     5D      $		 120 6-   $ 	Documento��5G   -    .   5E   -   �� *TipoDocumento+# [ 5H   -     5I      $
	 Auto 6-      DataFormatString$  {0:dd/MM/yyyy hh:mm}��5J   -   $ 	F. Inicio��5L   -    .   5K   -   �� *FechaInicio+5M   -     5N      $
	 Auto 6-   $  {0:dd/MM/yyyy hh:mm}��5O   -   $ F. Indicada��5Q   -    .   5P   -   �� *FechaIndicada+5R   -     5S      $
	 Auto 6-    
  MinWidth$	 120Q�5T   -   $  {0:dd/MM/yyyy hh:mm}��5U   -   $ 
F. Entrega��5W   -    .   5V   -   �� *FechaEntrega+5X   -   2  ,Telerik.Windows.Controls.GridViewImageColumn  5c      $ 	En tiempo��5e   .      ImageStretch$
 None=�5f   .    5c   .   �� *
EnTiempo+# [ 5f   .      RowStyle 5h      �� 5i       �� 
TargetType3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5j      ��  �� Property � �� �� Value 63   �� *IdPrioridad+# [ 5k      5m      5n      5o      