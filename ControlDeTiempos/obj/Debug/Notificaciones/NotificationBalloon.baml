   M S B A M L   `   `   `  ����A  =Notify, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Notify;assembly=NotifyNotify  5       ControlDeTiempos9   3ControlDeTiempos.Notificaciones.NotificationBalloon   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7Notify$clr-namespace:Notify;assembly=Notify     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          >�Name$  me��5      $	��550��5      $	��200��5	       � 	Resources 5       
  FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut��%�  &	        &	     &	 �    &	 �    &	 �    �� 5   
   .��5      U� $ 00:00:00X�6,   $
 grid��5   ,   $ (UIElement.Opacity)�5   ,   .\�5      �� $ 00:00:00��6'   $ 0Q�6:   �� 5      $ 00:00:01��6'   $
 0.95Q�6:   �� 5      $ 00:00:03��6'   $
 0.95Q�6:   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��5   ,   $ (UIElement.Opacity)�5   ,   .\�5      �� $ 00:00:00��6'   $	 0.4Q�6:   �� 5      $ 00:00:00.3000000��6'   $ 1Q�6B   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��5    ,   $ (UIElement.Opacity)�5!   ,   .\�5"      �� $ 00:00:00��6'   $ 1Q�6:   �� 5#      $ 00:00:00.3000000��6'   $	 0.4Q�6B   5$      5%      �� 5&   
   .��5'      U� $ 00:00:00X�6,   $
 grid��5(   ,   $ (UIElement.Opacity)�5)   ,   .\�5*      �� $ 00:00:00��6'   $ 1Q�6:   �� 5+      $ 00:00:00.3000000��6'   $ 1Q�6B   5,      5-      �� 5.   
   -   5        .��5/      U� $ 00:00:00X�6,   $
 grid��50   ,   $ (UIElement.Opacity)�51   ,   .\�52      �� $ 00:00:00��6'   $ 1Q�6:   �� 53      $ 00:00:00.3000000��6'   $	 0.2Q�6B   54      55      56       � Triggers 57      :� 58   
    :� RoutedEvent$' !Notify:TaskbarIcon.BalloonShowing��6   .[�59      �� -   5        	 ��Name$	 FadeIn_BeginStoryboard��59      #��[  6>   5:      :� 5;   
   $ Mouse.MouseEnter��6   
 :� 
SourceName$
 imgClose��66   .[�5<      �� -   5        $*	 $HighlightCloseButton_BeginStoryboard��5<      #��[ 6L   5=      :� 5>   
   $ Mouse.MouseLeave��6   $
 imgClose��66   .[�5?      �� -   5        $%	 FadeCloseButton_BeginStoryboard��5?      #��[ 6G   5@      :� 5A   
   $ Mouse.MouseEnter��6   .[�5B      ��  �� BeginStoryboardName$ FadeIn_BeginStoryboard��6   �� 5C      -   5        $	 FadeBack_BeginStoryboard1��5C      #��[ 6A   5D      :� 5E   
   $' !Notify:TaskbarIcon.BalloonClosing��6   .[�5F      �� -   5        $	 FadeOut_BeginStoryboard��5F      #��[ 6?   5G      .��5I      � -   5         �Name$
 grid��5I      .+�5J   
   �� $��5,5,5,5q�6   $��Stretch=�5K      ���#1ba1e2$��1,1,1,1q�5M       J� Effect 5N      3  -System.Windows.Media.Effects.DropShadowEffect  5O         Color$ 	#FF747474��6#   ��5Q      �� 5R       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5S      �  � Offset$ 0Q�6#    � Color$ 	#FF4B4B4B��6.   � 5T      $ 1Q�6#   $ 	#FF8F8F8F��6.   5U      5W      �� 5X   
   $	��128��6   $	��128��5Y      $��	15,30,0,0q�5Z      $
��Left=�5[      $	��Top=�5\      $9��3/ControlDeTiempos;component/Resources/clock_128.png��5]      $
��Fill=�5^      A� 5`   
   -	   5         A�Name$ 	RedCircle��5`      $��50��5a      $��50��5b      $��
180,50,0,0q�5c      $
��Left=�5d      $	��Top=�5e      
���  ��5f      A� 5g   
   -
   5        $ YellowCircle��5g      $��50��5h      $��50��5i      $��180,120,0,0q�5j      $
��Left=�5k      $	��Top=�5l      
��� ���5m      �� 5o   
   -   5        $��TxtInfo��5o      $��250,55,10,0q�5p      $	��Top=�5q      ���	#FFECAD25$
��Wrap=�5s      �� 6)    � Language$ de-ch�6-   $>�8This is a user control. The animation uses the attached ��6>   �� 6�   $��Italic$�6�   $
��Bold"�5t      $ de-ch�5u      $�BalloonShowing ��5v      �� 6,   $ de-ch�60   $�event.��6A   5w      �� 5y   
   -   5        $��TxtPorVencer��5y      $��250,125,10,0q�5z      $	��Top=�5{      ���	#FFECAD25$
��Wrap=�5}      �� 6)   $ de-ch�6-   $>�8This is a user control. The animation uses the attached ��6>   �� 6�   $��Italic$�6�   $
��Bold"�5~      $ de-ch�5      $�BalloonShowing ��5�      �� 6,   $ de-ch�60   $�event.��6A   5�      F� 5�   
   $��1��6   $��180,38.2,10,0q�5�      $	��Top=�5�      ���Ѐ����`����`	���#1ba1e2 J� SnapsToDevicePixels .  �� Stretch$
 Fill=�5�      ��5�      �� 5�      $ 	0.005,0.5&�6&   $ 	0.973,0.5&�6=   .��5�      � $ 1Q�6#   $ 	#00ECAD25��6.   � 5�      $ 0Q�6#   $ #1ba1e2��6.   5�      5�      �� 5�   
   $
��23.2��6   $��180,10,10,0q�5�      $	��Top=�5�      $
��Bold"�5�      ���	#FFECAD25$
��Wrap=�5�      ��5�      ��  �� Path$ BalloonText� �� ElementName$ me�� �� Mode$ Default=�5�      �� 5�   
   -   5         ��Name$ imgClose��5�      $��16��5�      $��16��5�      $��	0,10,10,0q�5�      $��Right=�5�      $	��Top=�5�       J� Opacity$	 0.4Q�5�      $5��//ControlDeTiempos;component/Resources/Close.png��5�      $
��Fill=�5�       � ToolTip$ Close Balloon��5�      5�      5�      