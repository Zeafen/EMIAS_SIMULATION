   M S B A M L   `   `   `  ����G  CClient_Emias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client_EmiasClient_Emias  5      /    )Client_Emias.PatientPages.PatientMainPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client_Emias     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        N� Title$  PatientMainPage��5
         PrimaryBackground N� 
Background# �   6l    � DataContext 6   ��  �� RelativeSource �� *Self+ �� Path$ 	patientVM�.��5      �� .��5   
   �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��Запись��6     PrimaryBigTextBlock#���  6"   $
��5,10q�6P   �� 5   
   -   5        $��1��5      #���   6"   ��6S   �� *availableDoctors+ �� SelectedItem 6|   �� *SelectedDoctor+��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6    5      5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       $
��auto �6#   �� 5!      $
��auto �6#   .+�5$      �� $'��!Дейсвующие записи��6   #���  61   $��10q�6_   (  "System.Windows.Controls.DatePicker  5%      -   5        $��ArchivedFrom��5%      $��1��6-   $	��100��6=   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Записи с��6�   $��5q�6�   $	��0.5q�6�   $��5q�6�   
�������6�     5&      -   5        $��
ArchivedTo��5&      $��2��6+   $	��100��6;   $	 Записи по��6   $��5q�6�   $	��0.5q�6�   $��5q�6�   
�������6�   5'      5)      5*      5+      