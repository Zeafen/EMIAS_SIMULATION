   M S B A M L   `   `   `  ���� G  CClient_Emias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client_EmiasClient_Emias  /    )Client_Emias.PatientPages.PatientMainPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:Client_Emias     _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  PatientMainPage��   PrimaryBackground N� 
Background# �    � DataContext ��  �� RelativeSource �� *Self+ �� Path$ 	patientVM�.���� .���  � RowDefinitions �� $
��Auto ��� �� $
��auto ��� $
��auto ��� .+��� $��Запись��  PrimaryBigTextBlock#���  $
��5,10q��� -   $��1��#���   ���� *availableDoctors+ �� SelectedItem �� *SelectedDoctor+���� .R��  � Orientation$ 
Horizontal=�� $��2�� � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� $'��!Дейсвующие записи��#���  $��10q�(  "System.Windows.Controls.DatePicker  -   $��ArchivedFrom��$��1��$	��100��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Записи с��$��5q�$	��0.5q�$��5q�
�������  -   $��
ArchivedTo��$��2��$	��100��$	 Записи по��$��5q�$	��0.5q�$��5q�
�������