   M S B A M L   `   `   `  ����F  BWarfighters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Warfighters.PagesWarfighters.Pages  5      "    Warfighters.Pages.Calculator   5      Z VDevExpress.Mvvm.UI, Version=24.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Warfighters.Pages     5        N� Title$  
Calculator��5	      .��5
      � ���	#F2FFFFFF � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6%   $��2��62   $��Center=�6C   $��Center=�6`   .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $#��Сет артефактов: ��6    $	��125��68   $��3q�6D   $��15��6O   �� 5      -   5         ��Name$ cbSet��5      $	��140��6.   $��3q�6:      ComboBoxCalc#��[  6E   5      �� 5      $ 
Horizontal=�6   .+�5      �� $-��'Категория артефакта: ��6    $	��125��6=   $��3q�6I   $��15��6T   �� 5      -   5        $ cbPiece��5      $	��140��60   $��3q�6<   #��[  6G   6m   5      �� 5      $ 
Horizontal=�6   .+�5       �� $(��"Основная харак-ка: ��6    $	��125��6;   $��3q�6G   $��15��6R   �� 5!      -   5        $ 
cbMainStat��5!      $	��140��63   $��3q�6?   #��[  6J   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $/��)Процент от силы атаки: ��6    $	��140��6?   $��3q�6K   $��15��6V   �� 5&      -   5         ��Name$ tbATKPercent��5&        statTBStyle#��[ 64   $	��100��6Y   $��3q�6e   6p   5'      �� 5)      $ 
Horizontal=�6   .+�5*      �� $,��&Процент от здоровья: ��6    $	��140��6=   $��3q�6I   $��15��6T   �� 5+      -   5        $ tbHPPercent��5+      #��[ 63   $	��100��6X   $��3q�6d   6o   5,      �� 5.      $ 
Horizontal=�6   .+�5/      �� $(��"Процент от защиты: ��6    $	��140��6;   $��3q�6G   $��15��6R   �� 50      -   5        $ tbDEFPercent��50      #��[ 64   $	��100��6Y   $��3q�6e   6p   51      �� 53      $ 
Horizontal=�6   .+�54      �� $$��Восст. энергии %: ��6    $	��140��6:   $��3q�6F   $��15��6Q   �� 55      -   5        $ 
tbRecharge��55      #��[ 62   $	��100��6W   $��3q�6c   6n   56      �� 58      $ 
Horizontal=�6   .+�59      �� $)��#Мастерство стихий: ��6    $	��140��6;   $��3q�6G   $��15��6R   �� 5:      -   5        $
 tbEM��5:      #��[ 6,   $	��100��6Q   $��3q�6]   6h   5;      �� 5=      $ 
Horizontal=�6   .+�5>      �� $��Крит. урон %: ��6    $	��140��66   $��3q�6B   $��15��6M   �� 5?      -	   5        $ 	tbCritDMG��5?      #��[ 61   $	��100��6V   $��3q�6b   6m   5@      �� 5B      $ 
Horizontal=�6   .+�5C      �� $/��)Шанс крит. попадания %: ��6    $	��140��6@   $��3q�6L   $��15��6W   �� 5D      -
   5        $ 
tbCritRate��5D      #��[ 62   $	��100��6W   $��3q�6c   6n   5E      5F      �� 5H      .+�5I      �� -   5         ��Name$ bCheck��5I      $��Проверить��6)   $��5q�6=   ��6H   �� *CalculateWnd+�� 5J      -   5        $ bCansel��5J      $��Очистить��6*   $��5q�6=   ��6H   �� *	CancelWnd+5K      5L      �� 5M   
   $��1��6   $��0��6%   $��2��62   $��5q�6C   .+�5N      �� -   5        $ tbSearch��5N      $	��150��6(   $��Right=�64   $��Center=�6P   $��5q�6�   ��6k   �� *Search+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5O      $ Vertical=�6   .+�5P      �� $X��RПерсонажи, которым подходит данный артефакт:��6   $
��Bold"�6P   $��14(�6b   $
��Left=�6p   $
��Wrap=�6�   �� 5Q      -   5        	 ��Name$	 lvSuitableCharacters��5Q      ���	#F2FFFFFF$��Disabled=�6�   $��Center=�6�   ��69   �� *SuitableCharactersImages+��5R      �� 5S      .R�5T      � 5U      5W      �� 5X      -   5        
 ��Name$
 tbText��5X      $����Если вы не увидели интересующего персонажа, значит данный артефакт ему не подходит��6,   $��10q�5Y      $
��Wrap=�5Z      $y�	Collapsed=�60   5[      5\      5]      5^      