   M S B A M L   `   `   `  ����K  GControlDeTiempos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ControlDeTiempos.ConverterControlDeTiempos.Converter  5      8    2ControlDeTiempos.Formularios.SetOperativoForAsunto   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >	converter(clr-namespace:ControlDeTiempos.Converter     5      m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7r	 nTelerik.Windows.Controls.ScheduleView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a
 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
     	 
     5      -   5        $	��540��5      $	��800��5      $��SetOperativoForAsunto��5      (  "Telerik.Windows.Controls.RadWindow    WindowStartupLocation$  CenterScreen=�5
       � 	Resources 5      2   ,ControlDeTiempos.Converter.PersonalConverter   
nombreConv��%   &	          5   
   6&   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��20 �6   �� 5      $��50 �6   .+�5   
   �� $��	10,20,0,0q�6   $
��Left=�5      $	��Top=�5      $G��ASelecciona al personal que realizará las actividades señaladas:��5      $��14(�5      $
��Bold"�5      �� 5   
   -   5         ��Name$ LstOperativos��5      $��10,55,10,15q�5      $��Stretch=�5      $��Stretch=�5      ��5       �� ��5"      �� 5#      .R�5$      �  5%      �� 5&      $��30 �6,   �� 5'      $��76 �6,   .+�5*      �� $
��10,3q�6    $��Stretch=�5+       $��Stretch=�5,       $
��Bold"�5/       ��5-       �� *
IdPersonal+ �� 	Converter# [  5/       � 51      $��1��6    � ColumnDefinitions 52      �� 53   "   $��* �63   �� 54   "   $��* �63   .+�56      �� $��10,3,0,0q�6$   $
��Left=�57   $   $	��Top=�58   $   $��U. Asiganción:��59   $   �� 5:      $��	10,34,0,0q�6$   $
��Left=�5;   $   $	��Top=�5<   $   $��U. Entrega:��5=   $    � ToolTip$, &Fecha de la última entrega programada��5>   $   �� 5?      $	��140��6(   $��	100,5,0,0q�5@   (   $
��Left=�5A   (   $	��Top=�5B   (   ��5C   (   �� *UltimaAsignacion+ �� StringFormat$ {0:dd/MM/yyyy HH:mm tt}���� 5E      $	��140��6(   $��
100,36,0,0q�5F   (   $
��Left=�5G   (   $	��Top=�5H   (   ��5I   (   �� *UltimaEntrega+$ {0:dd/MM/yyyy HH:mm tt}���� 5K      $��1��6'   $
��10,0q�5L   '   $��Stretch=�5M   '   $��Stretch=�5N   '   $��Black"�5O   '   $��
Pendientes��5P   '   .��5Q   "   � .+�5R   &   �� $��10,3,0,0q�6,   $
��Left=�5S   ,   $	��Top=�5T   ,   $��Asuntos:��5U   ,   $��Normal"�5V   ,   �� 5W   &   $��71,3,0,0q�6,   $
��Left=�5X   ,   $	��Top=�5Y   ,   ��5Z   ,   �� *AsuntosPendientes+�� 5[   &   $��	10,25,0,0q�6,   $
��Left=�5\   ,   $	��Top=�5]   ,   $��Fojas:��5^   ,   $��Normal"�5_   ,   �� 5`   &   $��	71,25,0,0q�6,   $
��Left=�5a   ,   $	��Top=�5b   ,   ��5c   ,   �� *HojasPendientes+5d   #   5e      5f      5h      5i      5k      �� 5l   
   $��1��6   $	��500��5m      $��10,0,0,0q�5n      $
��Left=�5o      $	��Top=�5p      
���  ��$O��I**Se sugiere considerar el orden señalado para la asignación del asunto��5r      $
��Wrap=�5s      �� 5v   
   -   5         ��Name$ BtnCancelar��5v      $��2��5w      $��80��5x      $��	0,10,10,0q�5y      $��Right=�5z      $	��Top=�5{      $��Cancelar��5}        
BlueButton#��[ 5~      �� 5   
   -   5        $ 
BtnAsignar��5      $��2��5�      $��80��5�      $��	0,10,96,0q�5�      $��Right=�5�      $	��Top=�5�      $��Asignar��5�      #��[ 5�      5�      5�      