   M S B A M L   `   `   `  ����  ControlDeTiempos    ControlDeTiempos.VotosWin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��374��5      $	��318��5      $��Votos��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5	      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5
      .��5      � .+�5   
   �� $��	22,26,0,0q�6   $
��Left=�5      $	��Top=�5      $��Emisor del voto:��5      $��14(�5      $
��Bold"�5      *  $Telerik.Windows.Controls.RadComboBox  5   
   -   5          Name$ CbxEmisores��5      $	��309��5      $��	22,60,0,0q�5      $
��Left=�5      $	��Top=�5       �� DisplayMemberPath$ NombreCompleto��5         
IsEditable .    IsFilteringEnabled .  �� SelectedValuePath$ IdEmisor��5         TextSearchMode$ Contains=�5      ��5      �� 5      �� 5   
   $��
22,106,0,0q�6   $
��Left=�5      $	��Top=�5      $��Tipo de voto:��5       $��14(�5!      $
��Bold"�5"        5#   
   -   5        $ CbxTipoVoto��5#      $	��309��5$      $��
22,140,0,0q�5%      $
��Left=�5&      $	��Top=�5'      $ Descripcion��5(      $ IdTipoAsunto��5*      ��5)      �� 5*      �� 5+   
   $��164,186,0,0q�6   $
��Left=�5,      $	��Top=�5-      $��	Páginas:��5.      $��14(�5/      $
��Bold"�50      /  )Telerik.Windows.Controls.RadNumericUpDown  51   
   -   5          Name$ RnudPaginas��51   #   $��99��52   #   $��234,186,0,0q�53   #   $
��Left=�54   #   $	��Top=�55   #   	   	IsInteger	 . +  %Telerik.Windows.Controls.RadRangeBase
   Minimum$
 1Q�57   #      Value 58   #   �� *	Paginas+�� 59   
   -   5         ��Name$ BtnSalir��59      $��80��5:      $��253,238,0,0q�5;      $
��Left=�5<      $	��Top=�5=      $��Salir��5?       �� IsCancel .    
BlueButton#��[  5A      �� 5B   
   -   5        $ 
BtnGuardar��5B      $��80��5C      $��164,238,0,0q�5D      $
��Left=�5E      $	��Top=�5F      $��Guardar��5H      #��[  5I      5J      5K      