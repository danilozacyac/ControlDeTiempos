   M S B A M L   `   `   `  ����  ControlDeTiempos    ControlDeTiempos.TesisWin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��300��5      $	��250��5      $��Tesis��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5	      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5
      .��5      � .+�5   
   �� $��	10,28,0,0q�6   $
��Left=�5      $	��Top=�5      $!��Número de identificación:��5      $��14(�5      $
��Bold"�5      �� 5   
   -   5         ��Name$ TxtnumIdenti��5      $	��249��5      $��23��5      $��	10,62,0,0q�5      $
��Left=�5      $	��Top=�5      ��5      �� *NumIdentificacion+ �� Mode$ TwoWay=��� 5   
   $��
90,106,0,0q�6   $
��Left=�5      $	��Top=�5      $��	Páginas:��5      $��14(�5      $
��Bold"�5      /  )Telerik.Windows.Controls.RadNumericUpDown  5    
   -   5          Name$ RnudPaginas��5    #   $��99��5!   #   $��160,106,0,0q�5"   #   $
��Left=�5#   #   $	��Top=�5$   #      	IsInteger . +  %Telerik.Windows.Controls.RadRangeBase   Minimum$ 1Q�5&   #      Value 5'   #   �� *	Paginas+�� 5(   
   -   5         ��Name$ BtnSalir��5(      $��80��5)      $��179,164,0,0q�5*      $
��Left=�5+      $	��Top=�5,      $��Salir��5.      	 �� IsCancel	 .    
BlueButton#��[  50      �� 51   
   -   5        $ 
BtnGuardar��51      $��80��52      $��
90,164,0,0q�53      $
��Left=�54      $	��Top=�55      $��Guardar��57      #��[  58      5:      5;      