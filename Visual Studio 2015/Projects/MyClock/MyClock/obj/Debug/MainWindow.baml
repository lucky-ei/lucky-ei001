   M S B A M L   `   `   `  ����B  >MyClock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MyClockMyClock  5   	       MyClock.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MyClock     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��500��6)    � 
ResizeMode$ CanMinimize=�65    � 	Resources 5	         MyClock.ClockViewModel   clockViewModel��%   &	          5   
   6   5      .��5      ��  � DataContext 6   ��  �� Source# [  .+�5   
   �� -   5         ��Name$ 	textBlock��5       �� Left$	 300��6'   $
��Wrap=�69   
 �� Top$	 400��5   2   $��30(�6C   ��6   ��  �� Path$ DigitalDisplay�6C   �� 5   
   		 �� X1$		 250��6   	
 �� Y1$	
 260��6   	 �� X2$	 250��6!   	 �� Y2$	 100��6*   $��20��63   
���  �� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      z�5      �� 5       �� CenterX$	 250Q�6"    �� CenterY$	 250Q�60    �� Angle 6>   �� $ HourHandAngle�5       �� 5#   
   $		 250��6   $	
 280��6   $	 250��6!   $ 60��6*   $��10��62   
����  � 5$        5%      z�5(      �� 5*      $	 250Q�6"   $	 250Q�60    6>   �� $ MinuteHandAngle�5,      �� 5/   
   $		 250��6   $	
 290��6   $	 250��6!   $ 50��6*   $��5��62   
������� 50        51      z�54      �� 56      $	 250Q�6"   $	 250Q�60    6>   �� $ SecondHandAngle�58      A� 5:   
   $	 245��6   $	 245��6#   $��10��65   $��10��6@   
���   � 5;        5<      5>      5?      5@      