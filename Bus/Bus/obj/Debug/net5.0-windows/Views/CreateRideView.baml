   M S B A M L   `   `   `  ����>  :Bus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Bus.Views	Bus.Views  5          Bus.Views.CreateRideView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Bus.Views     5      .��5
      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  $��False��6   $��263,62,10,225q�69       AutoGenerateColumns$  False��6�      
IsReadOnly$
 True��6�   ��6P   �� *
Students+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� SelectedItem 6�   �� *SelectedStudent+$ PropertyChanged=�$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	FirstName+  5      $ 	Last Name��6%    68   �� *
LastName+  5      $ Parent��6%    65   �� *Parent.FirstName+  5      $ Class��6%    64   �� *Group.Title+4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� 	 �� Orientation$	 
Horizontal=�6)   .+�5   "   �� $��Update��67   $	��Add��6)   ��6E   �� 
 �� RelativeSource
 ��  �� AncestorType" >� �� Mode$ FindAncestor=� �� Path$# DataContext.AddStudentCommand�5      5         HeaderTemplate 5      �� 5       .R�5!      �� $��Action��6(   5"      5%      5)        5+   
   $��False��6   $��263,277,10,10q�69   $  False��6�   $
 True��6�   ��6P   �� *AddedStudents+$ PropertyChanged=�$ TwoWay=� 6�   �� *SelectedAddedStudent+$ PropertyChanged=�$ TwoWay=� 5-        5.      $ 
First Name��6%    69   �� *	FirstName+  5/      $ 	Last Name��6%    68   �� *
LastName+  50      $ Parent��6%    65   �� *Parent.FirstName+  51      $ Class��6%    64   �� *Group.Title+  53       54      �� 55      .R�56      �� $	 
Horizontal=�6)   .+�57   "   �� $��Update��6:   $��Remove��6)   ��6H   �� 
 �� " >�$ FindAncestor=�$&  DataContext.RemoveStudentCommand�58      59       5<      �� 5=      .R�5>      �� $��Action��6(   5?      5B      5F      �� 5H   
   $��Driver Name:��6   $
��Left=�6'   $��	10,62,0,0q�6B   $	��Top=�6U   �� 5I   
   $
��Left=�65   $��	92,62,0,0q�6P   $	��Top=�6c   ��6   �� *Driver.FirstName+6c   �� 5K   
   $��	Car Name:��6   $
��Left=�6$   $��
10,100,0,0q�6?   $	��Top=�6S   �� 5L   
   $
��Left=�65   $��
92,100,0,0q�6P   $	��Top=�6d   ��6   �� *Driver.Car.Title+6d   �� 5N   
   $��Car Number:��6   $
��Left=�6&   $��
10,136,0,0q�6A   $	��Top=�6U   �� 5O   
   $
��Left=�66   $��
92,136,0,0q�6Q   $	��Top=�6e   ��6   �� *Driver.Car.Number+6e   �� 5Q   
   $��Student Attend:��6   $
��Left=�6*   $��
10,175,0,0q�6E   $	��Top=�6Y   �� 5R   
   $
��Left=�61   $��101,175,0,0q�6L   $	��Top=�6a   ��6   �� *StudentCount+6a   �� 5T   
   $��
Max Seats:��6   $
��Left=�6%   $��
10,217,0,0q�6@   $	��Top=�6T   �� 5U   
   $
��Left=�69   $��
92,217,0,0q�6T   $	��Top=�6h   ��6   �� *Driver.Car.SeatCount+6h   �� 5W   
   $
��Left=�6   $��
10,260,0,0q�6.   $	��Top=�6B   $	��120��6Z    6f   �� *Driver+$ PropertyChanged=�$ TwoWay=���6�   �� *	Drivers+$ PropertyChanged=�$ TwoWay=��� 5X   
   $��Create��6   $
��Left=�6"   $��
10,408,0,0q�6=   $	��Top=�6Q   ��6i   �� *CreateCommand+5\      5_      