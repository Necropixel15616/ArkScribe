   M S B A M L   `   `   `  ���� M  IArkScribe.FrontEnd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ArkScribeFrontEnd.ViewsArkScribeFrontEnd.Views  &     ArkScribeFrontEnd.Views.MainMenu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:ArkScribeFrontEnd.Views       N� Title$  MainMenu��.��� 
���OO/� � ColumnDefinitions �� $��10 ��� $��* ��� $��10 ��� $��50 ��� $	��100 ��� $	��125 ��� $��10 ��� $	��125 ��� $	��100 ��� $��50 ��� $��10 ��� $��* ��� $��10 � � RowDefinitions �� $��5 ��� $��* ��� $��30 ��� $��40 ��� $��10 ��� $��25 ��� $	��225 ��� $��10 ��� $��50 ��� $��5 �.+��� -   $��lblArkScribe��$��
Ark Scribe��
����� �$��1��$��5��$
��Bold"�$��16(�$��Center=�$��Center=�$��3��$��2���� -    ��Name$ btnCreateProject��
���   �$��2q�$��Create Project��$��3��$��5��$��3��$	��200��&   System.Windows.Controls.DataGrid  -     Name$ ProjectsDataGrid��
�������$��2q�
���   �   CanUserAddRows$ False��   AutoGenerateColumns$ False��$��5��$��2��$��3��$��7��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��	   
Visibility$	 Hidden=�1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Id+  $ Project��   
IsReadOnly$
 True��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 145 
 �� *Name+  $ Level��$
 True��$	 100 
 �� *Generation.Level+  $ Total Mutations��$
 True��$	 100 
 �� *	Mutations+4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� $ btnEditProject��-   $��Mutate��$	��100��   �� .R��� $ btnDeleteProject��-   $��Delete��$	��100��