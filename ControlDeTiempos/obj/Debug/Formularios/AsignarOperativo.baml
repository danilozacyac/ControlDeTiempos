   M S B A M L   `   `   `  ����  ControlDeTiempos3    -ControlDeTiempos.Formularios.AsignarOperativo   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��317��5      $	��381��5      $ ��Asignar personal operativo��5      )  #Telerik.Windows.Controls.WindowBase    
ResizeMode$  NoResize=�5	      (  "Telerik.Windows.Controls.RadWindow   WindowStartupLocation$ CenterScreen=�5
      .��5      � .+�5   
   �� $��	23,35,0,0q�6   $
��Left=�5      $	��Top=�5      $��
Asignar a:��5      $��14(�5      $
��Bold"�5      *  $Telerik.Windows.Controls.RadComboBox  5   
   -   5          Name$ CbxPersonal��5      $	��250��5      $��	23,69,0,0q�5      $
��Left=�5      $	��Top=�5       �� DisplayMemberPath$ NombreCompleto��5       �� SelectedValuePath$ 
IdPersonal��5      ��5      �� 5      �� 5   
   -   5         ��Name$ BtnCancelar��5      $��80��5      $��193,299,0,0q�5      $
��Left=�5      $	��Top=�5      $��Cancelar��5          
BlueButton#��[  5!      �� 5"   
   -   5        $ 
BtnAsignar��5"      $��80��5#      $��108,299,0,0q�5$      $
��Left=�5%      $	��Top=�5&      $��Asignar��5(      #��[  5)      �� 5*   
   $	��250��6   $��
23,106,0,0q�5+      $
��Left=�5,      $	��Top=�5-      
���  ��$O��I**Se sugiere considerar el siguiente orden para la asignación del asunto��5/      $
��Wrap=�50      �� 51   
   -   5         ��Name$ LstSugerido��51      $	��250��52      $	��144��53      $��
23,150,0,0q�54      $
��Left=�55      $	��Top=�56      $ NombreCompleto��57      ��58      �� 5:      5;      