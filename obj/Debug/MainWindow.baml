   M S B A M L   `   `   `  ����P  LFileSortingSystemV2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FileSortingSystemV2._0FileSortingSystemV2._0  5   	   '    !FileSortingSystemV2._0.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:FileSortingSystemV2._0     5   	   -   5          � Title$  Sorting System V2.01��5   	   $	��510��6&   $	��400��63    � WindowStartupLocation$ CenterScreen=�6?    � 	Resources 5	         
canvasPath �� 
TargetType �� Property �� Value  pathText��%T  &	        &	 t     �� 5
   
   " ��6#   .�5      ��  � ��$ 40��6'   �� 5       � �� �	#FF2C2C2C6+   5      �� 5   
   " ��6!   .�5      ��  � ��$ 40��6'   64   �� 5       � ��$	 350��6&   64   �� 5       � ��$ 16(�6)   66   �� 5       � �� �	#FFFFEC946?   5      5      .��5      � ���	#FF1D1D1D.+�5   
   �� -   5         ��Name$ sortPathBtn��5      $	��...��6&   $��Right=�64   $��	0,41,10,0q�6P   $	��Top=�6c   $��40��6{   $��34��6�   $��18(�6�   ���	#FF1D1D1D���	#FFFFD100���	#FFFFEC946�   �� 5   
   -   5        $ sortBtn��5      $��Сортировать��6"   $��
10,0,10,10q�68   $��Bottom=�6L   $��40��6g   $��16(�6s   $��Center=�6�   ���	#FF1D1D1D���	#FFFFD100���	#FFFFEC946�   �� 5   
   -   5         ��Name$ sortPathBox��5      $��34��6'   $��
10,41,55,0q�63   $ ��Укажите путь...��6G    �� 	UndoLimit$	 512��6^   $��16(�6n   $��Center=�6|   $��10,0,0,0q�6�   $	��Top=�6�   ���	#FF1D1D1D���	#FFFFEC94���	#FFFFD1006  �� 5   
   $4��.Путь до папки сортировки:��6   $��	10,5,10,0q�64   $	��Top=�6G   	 J� RenderTransformOrigin$	 0.259,0.455&�6_   $��16(�6�   ���	#FFFFEC94���	#FF1D1D1D���	#FFFFD1006�   �� 5   
   $��10,130,10,60q�6   $��Stretch=�6-   $
��Auto=�6R   .��5      �� -   5        
 ��Name$
 
pathsPanel��5      $��40��6-   $	��350��69   $	��Top=�6E   5      5      �� 5   
   -   5        $ addBtn��5      $��Добавить��6!   $��	10,80,0,0q�64   $	��Top=�6G   $��40��6_   $��16(�6k   $
��Left=�6�   $
��15,1q�6�   ���	#FF1D1D1D���	#FFFFD100���	#FFFFEC946�   �� 5   
   -   5        $ settingsBtn��5      $��Настройки��6&   $��
114,80,0,0q�6:   $	��Top=�6N   $��40��6f   $��16(�6r   $
��Left=�6�   $
��15,1q�6�   $	��125��6�   ���	#FFFFD100���	#FF1D1D1D���	#FFFFEC94$y�Hidden=�6  5       5!      