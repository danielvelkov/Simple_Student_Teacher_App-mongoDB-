   M S B A M L   `   `   `  ����F  BStudentTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentTest.ViewsStudentTest.Views  5      -    'StudentTest.Views.RegisterTeacherScreen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:StudentTest.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��0.2* �6   �� 5      $
��0.3* �6   �� 5      $
��0.4* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Name:��6   $��Right=�6    $��Center=�6=   �� 5    
   $��Faculty:��6   $��2��6#   $��Right=�60   $��Center=�6M   �� 5!   
   $��Civil Number:��6   $��1��6(   $��Right=�65   $��Center=�6R   �� 5"   
   $��Phone Number:��6   $��3��6(   $��Right=�65   $��Center=�6R   �� 5#   
   $��Email:��6   $��4��6!   $��Right=�6.   $��Center=�6K   �� 5%   
   $��1��6(   $��0��68   $��Center=�6E   $��20,0,0,0q�6`   $��18(�6r   $��2��6�   ��6   �� *Name+6�   �� 5&   
   $��1��6,   $��1��6<   $��Center=�6I   $��20,0,0,0q�6d   $��18(�6v   $��2��6�   ��6   �� *
CivilNum+6�   �� 5'   
   $��20,0,0,0q�6]   $��1��6p   $��2��6�   $��Center=�6�   $��18(�6�   $��2��6�    �� SelectedItem 6   �� *TeacherFaculty+��6;   �� *	Faculties+6�   �� 5(   
   $��1��6,   $��3��6<   $��Center=�6I   $��20,0,0,0q�6d   $��18(�6v   $��2��6�   ��6   �� *
PhoneNum+6�   �� 5)   
   $��1��6)   $��4��69   $��Center=�6F   $��20,0,0,0q�6a   $��18(�6s   $��2��6�   ��6   �� *Email+6�   �� 5+   
   $��1��6,   $��7��6<   $��2��6I   $��Center=�6]   $��Center=�6x   
���  ��$��20(�6�   ��6   �� *ErrMsg+6�   �� 5,   
   $��1��61   $��8��6A   $��10q�6N   $��2��6Z   $��Save Teacher��6n   ��6   �� *SaveTeacher+6n   � 5.   
   $��1��6   $��5��6   $��2��6,   $��2��6@     5/      �� 50      6%   �� 51      6%   �� 52      6%   .+�55      �� $��Subjects��6   .��56      �� $��0��6d   ��6   �� *
Subjects+ 6;   �� *SelectedSubject+6x   57      �� 59      $��1��6   .+�5:      �� $	��Add��68   ��6   �� *
AddSubject+6H   �� 5;      $��Remove��6;   ��6   �� *RemoveSubject+6N   5<      �� 5=      $��Taught Subjects��6   $��2��60   .��5>      �� ��6   �� *TaughtSubjects+ 6A   �� *SelectedTaughtSubject+6s   5?      5A      5E      5F      