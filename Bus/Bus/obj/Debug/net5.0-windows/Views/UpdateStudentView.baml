   M S B A M L   `   `   `  ����>  :Bus, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Bus.Views	Bus.Views  5      !    Bus.Views.UpdateStudentView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Bus.Views     5      .��5
      � 
�������.+�5   
   �� -   5        $��	FirstName��5      $
��Left=�6#   $��	10,32,0,0q�6>     �� TextWrapping$
  Wrap=�6Q   $	��Top=�6e   $	��367��6}   $��38��6�   $��16(�6�   ��6�   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5   
   -   5        $��LastName��5      $
��Left=�6"   $��	10,97,0,0q�6=   $
  Wrap=�6P   $	��Top=�6d   $	��367��6|   $��38��6�   $��16(�6�   ��6�   �� *
LastName+$ PropertyChanged=�$ TwoWay=��� 5   
   $��Parent��6   $
��Left=�6!   $��
10,140,0,0q�6<   $	��Top=�6P   $��44��6h   $��89��6t   $��14(�6   �� 5   
   $��	FirstName��6   $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   $��44��6j   $��89��6v   $��14(�6�   �� 5   
   $��LastName��6   $
��Left=�6#   $��	10,75,0,0q�6>   $	��Top=�6Q   $��44��6i   $��89��6u   $��14(�6�   �� 5   
   $��Class��6   $
��Left=�6    $��
10,214,0,0q�6;   $	��Top=�6O   $��44��6g   $��89��6s   $��14(�6~   �� 5   
   $��Update Student��6   $
��Left=�6*   $��674,408,0,0q�6E   $	��Top=�6Z   $	��116��6�   ��6r   �� *UpdateStudentCommand+6�   �� 5   
   $
��Back��6   $
��Left=�6    $��
728,10,0,0q�6;   $	��Top=�6O   ��6g   �� *NavigateBackCommand+�� 5   
   -   5        $��	ParentCmb��5      $
��Left=�6$   $��
10,184,0,0q�6?   $	��Top=�6S   $	��367��6k    �� SelectedItem 6w   �� *
ParentName+$ PropertyChanged=�$ TwoWay=���6�   �� *ParentNames+$ PropertyChanged=�$ TwoWay=��� 5   
   -   5        $��ClassCmb��5      $
��Left=�6#   $��
10,258,0,0q�6>   $	��Top=�6R   $	��367��6j    6v   �� *	ClassName+$ TwoWay=�$ PropertyChanged=���6�   �� *
ClassNames+$ TwoWay=�$ PropertyChanged=��� 5   
   $��Home Address��6   $
��Left=�6'   $��
10,288,0,0q�6B   $	��Top=�6V   $��44��6n   $	��112��6z   $��14(�6�   �� 5   
   -   5        $��HomeAddress��5      $
��Left=�6%   $��
10,310,0,0q�6@   $
  Wrap=�6T   $	��Top=�6h   $	��367��6�   $��38��6�   $��16(�6�   ��6�   �� *HomeAddress+$ TwoWay=�$ PropertyChanged=��� 5   
   $��Other Address��6   $
��Left=�6(   $��
10,353,0,0q�6C   $	��Top=�6W   $��44��6o   $	��112��6{   $��14(�6�   �� 5   
   -   5        $��OtherAddress��5      $
��Left=�6&   $��
10,375,0,0q�6A   $
  Wrap=�6U   $	��Top=�6i   $	��367��6�   $��38��6�   $��16(�6�   ��6�   �� *OtherAddress+$ TwoWay=�$ PropertyChanged=�5      5      