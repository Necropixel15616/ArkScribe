   M S B A M L   `   `   `  ����M  IArkScribe.FrontEnd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ArkScribeFrontEnd.ViewsArkScribeFrontEnd.Views  5      &     ArkScribeFrontEnd.Views.MainMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ArkScribeFrontEnd.Views     5        N� Title$  MainMenu��5	      .��5      � ��5   
   �� 5       �� ImageSource$; 5/Resources/4.jpg.922b13a84f27833b97127f97180d65fa.jpg��6    j� Stretch$ UniformToFill=�6]    � ColumnDefinitions 5   
   �� 5      $��10 �6   6,   �� 5      $��* �6   6+   �� 5      $��10 �6   6,   �� 5      $��25 �6   6,   �� 5      $��25 �6   6,   �� 5      $��50 �6   6,   �� 5      $��50 �6   6,   �� 5      $	��125 �6   6-   �� 5      $��10 �6   6,   �� 5      $	��125 �6   6-   �� 5      $��50 �6   6,   �� 5      $��50 �6   6,   �� 5      $��25 �6   6,   �� 5      $��25 �6   6,   �� 5      $��10 �6   6,   �� 5      $��* �6   6+   �� 5       $��10 �6   6,    � RowDefinitions 5"   
   �� 5#      $��5* �6   6*   �� 5$      $��40 �6   6*   �� 5%      $��30 �6   6*   �� 5&      $��40 �6   6*   �� 5'      $��10 �6   6*   �� 5(      $��30 �6   6*   �� 5)      $	��225 �6   6+   �� 5*      $��10 �6   6*   �� 5+      $��50 �6   6*   �� 5,      $��5* �6   6*   .+�5.   
   �� -   5        $��lblArkScribe��5.      $��
Ark Scribe��6$   
�������$��1��6Q   $��7��6^   $
��Bold"�6n   $��30(�6�   $��Center=�6�   $��Center=�6�   $��3��6�   $��2��6�   6�   �� 5/   
   -   5         ��Name$ btnCreateProject��5/      
���OO/�
�������$
��Bold"�6^   
���   �$��2q�6�   $��Create Project��6�   $��3��6�   $��7��6�   $��3��6�   $	��200��6�   $��14(�6  &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ ProjectsDataGrid��50      
���OO/�   CanUserAddRows$ False��6I      GridLinesVisibility$
 None=�6`   	   AutoGenerateColumns$	 False��6{   $��5��6�   $��2��6�   $��5��6�   $��7��6�   $��2q�6�   
   CanUserResizeColumns$
 False��6�      CanUserResizeRows$ False��6
     RowHeaderWidth$ 0Q�6$     ColumnHeaderStyle 51      �� 52       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�53      ��  �� Property � �� �� Value
 �OO/�6;   �� 54       � ��
 �����63   �� 55       � ��$
 Bold"�63   �� 56       � ��$ 40��6/   �� 57       � ��$ Center=�6A   58      ��5:      �� 5;       �� Color$ DarkSlateGray��6"    �� Opacity$
 0.75Q�68      RowStyle 5=      �� 5>      .�5?      ��  � ��
 ���� 6@   �� 5@       � ��
 �����6@   �� 5A       � ��$ 30��6<   �� 5B       � ��$
 Bold"�6@   �� 5C       � ��$ 14(�6>   5D         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
Visibility$ Hidden=�6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+5H        5I         Width5  /System.Windows.Controls.DataGridLengthConverter$ 20 6%   62     5J      $ PROJECT��6%      
IsReadOnly$
 True��66   $	 160 6a    6H   �� *Name+5K        5L      $ 10 6%   62     5M      $ LEVEL��6%   $
 True��64   $ 60 6k    6F   �� *Generation.Level+6k     5N      $       TOTAL 
 MUTATIONS��6%   $
 True��6J   $ 80 6z    6\   �� *	Mutations+6z   4  .System.Windows.Controls.DataGridTemplateColumn  5O         CellTemplate 5P      �� 5Q      .R�5R      �� $ btnEditProject��6%   -   5        $��40��5R   =   $��25��6e   
������ $��0q�6�    � ToolTip 5S   "   _� 5T   &   .��6.   Mutate5V   '   .��5X   "   �� $��/Resources/3370501.png��6(   5Y      5Z      5\        5]       5^      �� 5_      .R�5`      �� $ btnDeleteProject��6%   -   5        $��40��5`   ^   $��25��6i   
������ $��0q�6�    5a   "   _� 5b   &   .��6.   Delete5d   '   .��5f   "   �� $"��/Resources/delete-1-icon.png��6(   5g      5h      5j        5k      $ 20 6%   62   5m      5n      5o      