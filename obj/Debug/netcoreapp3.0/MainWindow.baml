   M S B A M L   `   `   `  ����B  >PostDog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PostDogPostDog  5   	       PostDog.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:PostDog     5   	     � Title$  
MainWindow��5   	   $	��850��6   $
��1200��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��4* �6   �� 5      $��3* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��4* �6   .+�5   
   �� $	��400��6   $	��Top=�6"   $��0��6:   .+�5      �� $��50��6   $
��Left=�6   .��6:   Name6@   �� 5      -   5        $��uriName��5      $	��864��6%   $
��Left=�61   6N   �� 5      $��50��6   $
��Left=�6   .��6:   Uri6?   �� 5      -   5        $	��uri��5      $	��864��6!   $
��Left=�6-   6J   �� 5      $��50��6   $
��Left=�6   .��6:   body6@   �� 5      -   5        $
��body��5      $	��100��6"   $	��853��6/   $
��Left=�6;   6X   	� 5      -   5        $��RadioButtonPost��5       	� 	GroupName$ rbType��62   $
��POST��6E   $
��Left=�6T   	� 5      -   5        $��RadioButtonGet��5      $ rbType��60   $	��GET��6C   $
��Left=�6Q   �� 5      -   5        $	��100��5      $
��Left=�6!   .��6R   Add6W   �� 5      -   5        $
��test��5      $	��100��6!   $
��Left=�6-   .��6]   	Hit it!6f   �� 5      -   5        $��testSomthing��5      $	��100��6)   $
��Left=�65   .��6k   Test something6{   �� 5       -	   5        $��lbUris��5        �� SelectionMode$ Single=�6$   $	��100��6;   $	��600��6H   $
��Left=�6T   ��5!      �� 5"      .R�5#      �� ��6$   �� *Title+5%      5'      5)      �� 5*   
   $��0��6   $��3��6%   $��1��69   .+�5+      �� -
   5        $��tbResult��5+      6*   5,      5-      5.      