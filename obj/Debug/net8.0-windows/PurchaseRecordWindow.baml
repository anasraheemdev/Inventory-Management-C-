   M S B A M L   `   `   `  ����B  >FinalDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinalDBFinalDB  5   Q   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   "    FinalDB.PurchaseRecordWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:FinalDB     6Q   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$#  SULTANI POS - Purchase Record��5   	   $	��720��6/   $
��1280��6<    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         MenuButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value  DataGridStyle&   System.Windows.Controls.DataGrid  DataGridColumnHeaderStyle*  $System.Windows.Controls.DataGridCell �� Padding)  #System.Windows.Controls.DataGridRow=  7System.Windows.Controls.Primitives.DataGridColumnHeader  PrimaryButtonStyle  SecondaryButtonStyle �� BasedOn  CardBorderStyle3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   Color  FormControlStyle ��Name �� SelectionBoxItem �� SelectionBoxItemTemplate# �� SelectionBoxItemStringFormat �� ContentStringFormat J� IsHitTestVisible d�Name d� 	IsChecked �� Path �� Mode �� RelativeSource F�Name �Name � AllowsTransparency �� IsDropDownOpen  ��Name  DropShadowEffect! J� Effect" �� MaxDropDownHeight# K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation$   DirectionalNavigation% � 	Resources  Key(  "System.Windows.Controls.DatePicker& �Name' � ColumnDefinitions:  4System.Windows.Controls.Primitives.DatePickerTextBox(  Name) ��Name&	   System.Windows.Controls.Calendar* 	 Name 	 FormLabelStyle��%�  &	        &	 i    7  &	 �    &	 �	    &	     7  &	 �    &	 q    '�� m    7  '�� g    7  7.�7  '  �    7  7.�7  &		 \    �� 5   
   " ��6(   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ 40��6'   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 15,0,0,0q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   $ 6��6�   ._�5      �� #��z��6/   $��Center=�6r   5      5      5       5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5      ��  � �� �#3672CF63   �� 5       � ��
 �����63   5       5"      �� 5$   
   "  6&   .�5%      ��  � ��
 �����6+   �� 5&       � �� �#E0E0E06,   �� 5'       �@ GridLinesVisibility$ 
Horizontal=�64   �� 5(       �@ HeadersVisibility$ Column=�62   �� 5)       �@ 	RowHeight$ 40Q�6*   �� 5*       �@��AlternationCount$ 2��61   �� 5+        �@ AlternatingRowBackground �#F9F9F969   �� 5,       � ��$ 0q�60   �� 5-       �@ CanUserAddRows$ False��6/   �� 5.       �@ AutoGenerateColumns$ False��64   �� 5/       �@ 
IsReadOnly$
 True��6+   �� 50       �@ ColumnHeaderStyle8   62   �� 51       �@ 	CellStyle 52      �� 53      "  6   .�54      ��  � ��$	 8,0q�64   �� 55       � ��$ 0q�6<   �� 56       � ��$ Center=�6E   �� 57       � �� 58      �� 59   "   "  62   .R�5:   &   �� # z��6-   #��z��6Q   #��z��6}   #��z��6�   ._�5;   *   �� 5<   '   5=   #   5?      5@      5B      �� 5C       �@ RowStyle 5D      �� 5E      "  6   .�5F      ��  �@J�SnapsToDevicePixels$
 True��6@   �� 5G       �@=�ErrorTemplate 6E   Z� �� 5H       � ��
 �����67    5I      P� 5J      	 �@��AlternationIndex$
 1��6O   . �5K   "   ��  � �� �#F9F9F96?   5L      P� 5M      	 �@ 
IsSelected$

 True��6<   . �5N   "   ��  � �� �#D8EDFF6?   �� 5O   "    � ��
 �   �6?   5P      P� 5Q      	 �@J�IsMouseOver$

 True��6=   . �5R   "   ��  � �� �#E0F2FF6?   �� 5S   "    �@�Cursor$
 Hand��6;   5T      5V      5X      5Y      �� 5[   
   "  62   .�5\      ��  � �� �#F0F5FF6+   �� 5]       � �� �#1E5AAF6+   �� 5^       � ��$ SemiBold"�6+   �� 5_       � ��$ 45��6'   �� 5`       � ��$	 8,0q�6(   5a      �� 5c   
   " ��6+   .�5d      ��  � �� �#1E5AAF6+   �� 5e       � ��
 �����6+   �� 5f       � ��$ 0q�60   �� 5g       � ��$
 15,8q�6(   �� 5h       � ��$ 0,0,10,0q�6'   �� 5i       � �� 5j      �� 5k      " ��6&   .R�5l      �� #��z��6!   $ 6��5m   !   #��z��5n   !   ._�5o      �� $��Center=�6/   $��Center=�5p   /   #��z��5q   /   5r      5s      5u       5v      P� 5w      	 �@J�IsMouseOver$

 True��61   . �5x      ��  � �� �#3672CF63   5y      5{      �� 5}   
   " ��6-   8   .�5~      ��  � �� �#E0E0E06+   �� 5       � �� �#1A1A1A6+    5�      P� 5�      	 �@J�IsMouseOver$

 True��61   . �5�      ��  � �� �#D0D0D063   5�      5�      �� 5�   
   " ��6(   .�5�      ��  � ��
 �����6+   �� 5�       � �� �#E0E0E06,   �� 5�       � ��$ 1q�60   �� 5�       �@��CornerRadius$ 10��6-   �� 5�       �@��Padding$ 18q�6(   �� 5�       �@J�Effect 5�        5�      $ 10Q�6'   $ 1Q�67   $	 0.1Q�6G   $ #000000��6U   5�      5�      �� 5�   
   " ��6)   .�5�      ��  � ��$ 32��6'   �� 5�       � ��$ 0q�6'   �� 5�       � �� �#E0E0E06,   �� 5�       � ��$ 1q�60   �� 5�       � ��$	 8,5q�6(   �� 5�       � ��$ Center=�69   �� 5�       � ��
 �����6+   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   #��z��5�   !   #��z��5�   !   $ 6��5�   !   ._�5�      �� #��z��6/   #��z��5�   /   5�      5�      5�      5�      �� 5�   
   " ��6   8   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   #��z��5�   !   #��z��5�   !   $ 6��5�   !   ._�5�      �� $ PART_ContentHost��6+   5�      5�      5�      5�      �� 5�   
   " ��6   8   .�5�      ��  � �� 5�      �� 5�      " ��6&   .R�5�      � .+�5�      �� #��z��6%   #��z��5�   %   #��z��5�   %   $ 6��5�   %   ._�5�   "   �� $
��Left=�63   $��Center=�5�   3   #��z 5�   3   #��z 5�   3   # z 5�   3   $ False��5�   3   #��z��5�   3   5�      d� 5�      $ toggleButton��6+   
������ 
������ $��0q�5�   +    5�   +   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+.��5�   "   F� $ arrow��6'   ���#1E5AAF$��Right=�5�   '   $��Center=�5�   '   "����        � 	=  	= � z     	$��0,0,10,0q�5�   '   5�      � 5�      $ 
PART_Popup��6$   $
 True��5�   $   $��Bottom=�5�   $   #��z 5�   $   8�� .��5�   "   �� $  dropDownBorder��6)   ���#1E5AAF$��1q�5�   )   
�������$ 6��5�   )   8!  ._�5�   &   �� $ ScrollViewer��63   #��z" 6I   .��5�   *   �� $
# True��65   $$ 	Contained=�6H   5�   '   5�   #   5�      5�      % 5�      ��  5�      DropShadowEffect $ 5Q�6H   $ 2Q�6W   $	 0.1Q�6g   $ #000000��6u   5�      5�      5�      5�      �� 5�   
   "  6   8   .�5�      ��  � �� 5�      �� 5�      "  6&   .R�5�      � $& 	PART_Root��6   ' 5�      �� 5�   "   $��* �63   �� 5�   "   $
��Auto �63   .+�5�      �� #��z��6%   #��z��5�   %   #��z��5�   %   $ 6��5�   %   ._�5�   "     $( PART_TextBox��64   $��0��5�   4   $
|�True��5�   4   #��z��5�   4   #��z��5�   4   #��z��5�   4   5      �� 5     $) PART_Button��6%   $��1��5  %   $|�False��5  %   $��Right=�5  %   $��0,0,5,0q�5  %   
������ $��0q�5  %   .��5  "   F� "���Ѐ��  	= р�[  z р�  	= 	���#1E5AAF$��2��6O   5	     � 5
     $ 
PART_Popup��6$   $
 True��5  $   $��Bottom=�5  $   8�� ��5  $   �� *IsDropDownOpen+ �� *TemplatedParent+$ TwoWay=�.��5  "   �� $  PART_CalendarBorder��6)   ���#1E5AAF$��1q�5  )   
�������$ 6��5  )   8!  ._�5  &   	  $* PART_Calendar��6/   5  #   5     5     % 5     ��  5     DropShadowEffect $ 5Q�6H   $ 2Q�6W   $	 0.1Q�6g   $ #000000��6u   5     5     5     5     �� 5!  
   " ��6'   .�5"     ��  � �� �#6E6E6E6+   �� 5#      � ��$ 0,0,0,5q�6'   �� 5$      � ��$ 12(�6)   5%     5&     .��5(     � ' 5)  
   �� 5*     $	��220 �6   �� 5+     $��* �6   .+�5.  
   �� ���#1E5AAF���#1648A0$��0,0,1,0q�6<   ._�5/     � + � RowDefinitions+ 50     �� 51     $��70 �6$   �� 52     $��* �6$   �� 53     $
��Auto �6$   .+�56     �� $��0��6   , �� Orientation$, 
Horizontal=�6*   $��20,0,0,0q�6C   $��Center=�6U   .+�57     �� $��SULTA��6    $��22(�6-   $
��Bold"�6;   
�������6M   �� 58     $��NI��6    $��22(�6*   $
��Bold"�68   ���#3CEFFF6J   �� 59     $
�� POS��6    $��16(�6,   ���#9DC3F5$��Bottom=�6O   $��5,0,0,2q�6j   5:     �� 5<     $��1��6   $
��Auto=�6,   .��5=     �� $��
10,20,10,0q�6!   .+�5>     �� -   5        #��[  5>  !   .��5?     �� $, 
Horizontal=�6)   .+�5@  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5A  "   $��	Dashboard��6,   $��SemiBold"�6=   5B     5C     �� 5E     $��CASHIER��6$   $��	15,20,0,5q�63   ���#9DC3F5$��12(�6[   $��SemiBold"�6i   �� 5F     -   5        #��[  5F  !   .��5G     �� $, 
Horizontal=�6)   .+�5H  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5I  "   $��Make Invoice��6,   5J     5K     �� 5L     -   5        #��[  5L  !   .��5M     �� $, 
Horizontal=�6)   .+�5N  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5O  "   $��Transaction��6,   5P     5Q     �� 5S     $��	INVENTORY��6$   $��	15,20,0,5q�65   ���#9DC3F5$��12(�6]   $��SemiBold"�6k   �� 5T     -   5        #��[  5T  !   .��5U     �� $, 
Horizontal=�6)   .+�5V  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5W  "   $��Add Item��6,   5X     5Y     �� 5Z     -   5        #��[  5Z  !   .��5[     �� $, 
Horizontal=�6)   .+�5\  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5]  "   $��Products List��6,   5^     5_     �� 5`     -   5        #��[  5`  !   ���#3672CF.��5a     �� $, 
Horizontal=�6)   .+�5b  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5c  "   $��Purchase Record��6,   5d     5e     �� 5f     -   5        #��[  5f  !   .��5g     �� $, 
Horizontal=�6)   .+�5h  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5i  "   $��Stock Tracking��6,   5j     5k     9� 5m     $��More Inventory��6#   ���#9DC3F5$��	10,10,0,0q�6P   
������ $��0q�5n  <   .��5o     �� .+�5p  "   �� -   5        #��[  5p  )   .��5q  &   �� $, 
Horizontal=�61   .+�5r  *   �� $	����64   $��Segoe MDL2 Assets)�6D   $��0,0,10,0q�6c   �� 5s  *   $��Category��64   5t  '   5u  #   �� 5v  "   -	   5        #��[  5v  )   .��5w  &   �� $, 
Horizontal=�61   .+�5x  *   �� $	����64   $��Segoe MDL2 Assets)�6D   $��0,0,10,0q�6c   �� 5y  *   $��Brand��64   5z  '   5{  #   �� 5|  "   -
   5        #��[  5|  )   .��5}  &   �� $, 
Horizontal=�61   .+�5~  *   �� $	����64   $��Segoe MDL2 Assets)�6D   $��0,0,10,0q�6c   �� 5  *   $��Units��64   5�  '   5�  #   �� 5�  "   -   5        #��[  5�  )   .��5�  &   �� $, 
Horizontal=�61   .+�5�  *   �� $	����64   $��Segoe MDL2 Assets)�6D   $��0,0,10,0q�6c   �� 5�  *   $��Supplier��64   5�  '   5�  #   �� 5�  "   -   5        #��[  5�  )   .��5�  &   �� $, 
Horizontal=�61   .+�5�  *   �� $	����64   $��Segoe MDL2 Assets)�6D   $��0,0,10,0q�6c   �� 5�  *   $��Issued��64   5�  '   5�  #   5�     5�     �� 5�     $��ADMINISTRATION��6$   $��	15,20,0,5q�6:   ���#9DC3F5$��12(�6b   $��SemiBold"�6p   �� 5�     -   5        #��[  5�  !   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�  "   $��Add Cashier��6,   5�     5�     �� 5�     -   5        #��[  5�  !   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�  "   $��Admin Login��6,   5�     5�     �� 5�     -   5        #��[  5�  !   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�  "   $��
Login Page��6,   5�     5�     �� 5�     -   5        #��[  5�  !   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�  "   $��Home (Login As)��6,   5�     5�     �� 5�     -   5        #��[  5�  !   $��0,20,0,0q�6j   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�  "   $��Edit Product (Example)��6,   5�     5�     5�     5�     �� 5�     $��2��6   ���#174B92���#144283$��0,1,0,0q�6Q   $ 15,12q�6k   ._�5�     �� $, 
Horizontal=�6!   .+�5�     �� $��36��6!   $��36��6,   ���#3CEFFF$ 18��6M   ._�5�     �� $��AR��6(   ���#0A2D5E$��Center=�6G   $��Center=�6d   $
��Bold"�6   5�     �� 5�     $��10,0,0,0q�6%   .+�5�     �� $��Anas Raheem��6(   $��SemiBold"�6;   $��14(�6Q   
�������6_   �� 5�     $��Administrator��6(   $��11(�6=   ���#9DC3F56K   5�     5�     5�     5�     5�     � 5�  
   $��1��6   ���#F6F9FC+ 5�     �� 5�     $��70 �6    �� 5�     $��* �6    .+�5�     �� 
����������#E0E0E0$��0,0,0,1q�6>   ._�5�     � ' 5�     �� 5�     $��* �6+   �� 5�     $
��Auto �6+   .+�5�     �� $��PURCHASE RECORD��6    $��22(�67   $
��Bold"�6E   $��Center=�6W   $��25,0,0,0q�6r   ���#1E5AAF6�   �� 5�     $��1��6!   $, 
Horizontal=�61   $��0,0,25,0q�6J   .+�5�     �� -   5        #��[ 5�  !   $��40��6M   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,8,0q�6[   �� 5�  "   $��New Purchase��6,   5�     5�     �� 5�     -   5        #��[ 5�  !   $��40��6O   .��5�     �� $, 
Horizontal=�6)   .+�5�  "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,8,0q�6[   �� 5�  "   $��Export��6,   5�     5�     5�     5�     5�     � 5�     $��1��6   $��25,15,25,25q�6    + 5�     �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $��* �6$   �� 5�     $
��Auto �6$   .+�5�     �� $��0��6   #��[ 6&   $ 18q�6O   $��0,0,0,15q�6\   ._�5�     � + 5�     �� 5�     $
��Auto �6,   �� 5�     $
��Auto �6,   ' 5�     �� 5�     $
��Auto �6/   �� 5�     $
��Auto �6/   �� 5�     $
��Auto �6/   �� 5�     $
��Auto �6/   �� 5�     $��* �6/   �� 5�     $
��Auto �6/   .+�5�     �� $��0��6%   $��0,0,15,0q�65   .+�5�     �� $��	From Date��6(   #��[	 69     5�     -   5        -  Name$- FromDatePicker��5�  )   $	��150��6A   #��[ 6M   .   SelectedDate. 6w   �� *
FromDate+$ TwoWay=�5�     �� 5�     $��1��6%   $��0,0,15,0q�65   .+�5      �� $��To Date��6(   #��[	 67     5     -   5        $- ToDatePicker��5  )   $	��150��6?   #��[ 6K   . 6u   �� *ToDate+$ TwoWay=�5     �� 5     $��2��6%   $��0,0,15,0q�65   .+�5     �� $��Supplier��6(   #��[	 68   �� 5     -   5        / ��Name$/ SupplierComboBox��5  '   $	��200��6A   #��[ 6M   ��5  '   �� *	Suppliers+0 �� SelectedItem0 6I   �� *SelectedSupplier+$ TwoWay=�5     �� 5
     $��3��6%   $��0,0,15,0q�65   .+�5     �� $��Status��6(   #��[	 66   �� 5     -   5        $/ StatusComboBox��5  '   $	��150��6?   #��[ 6K   ��5  '   �� *StatusOptions+0 6M   �� *SelectedStatus+$ TwoWay=�5     �� 5     -   5        1 ��Name$1 SearchTextBox��5  "   $��4��69   $��	0,20,15,0q�6I   $��32��6\   $��Center=�5  "   $	��8,0q�6D   ��5  "   �� *SearchQuery+2 �� UpdateSourceTrigger$2 PropertyChanged=�.��6d    5     ��%^   '��       �� 5  "   " ��6(   .�5  &   ��  �@��CornerRadius$ 6��6E   5  #   5     .��61   5     �� 5     $��5��6%   $, 
Horizontal=�65   $��Bottom=�6N   $��0,20,0,0q�6i   .+�5     �� -   5        $) ApplyFilterButton��5  %   #��[ 6@   $��Bottom=�5  %   $��32��6@   $��0,0,10,0q�6L   .��5  "   �� $, 
Horizontal=�6-   .+�5  &   �� $	����60   $��Segoe MDL2 Assets)�6@   $��0,0,8,0q�6_   �� 5  &   $��Apply Filter��60   5   #   5!     �� 5"     -   5        $) ClearFiltersButton��5"  %   #��[ 6A   $��Bottom=�5#  %   $��32��6@   .��5$  "   �� $, 
Horizontal=�6-   .+�5%  &   �� $	����60   $��Segoe MDL2 Assets)�6@   $��0,0,8,0q�6_   �� 5&  &   $��Clear Filters��60   5'  #   5(     5)     � 5+     $��1��6   $��6��6,   $��0,20,0,0q�6@   ' 5,     �� 5-  "   $��* �63   �� 5.  "   $��* �63   .+�50     �� $��0��6%   #��[ 65   $ 15q�6^   $��0,0,10,0q�6k   ._�51  "   �� .+�52  &   �� $��Total Sales Amount��60   ���#6E6E6E$��13(�6_   $��Medium"�6m   �� 53  &   $��22(�6V   $
��Bold"�6d   $��0,5,0,0q�6v   ���#1A1A1A��60   �� *TotalPurchasesAmount+6�   54  #   55     �� 56     $��1��6%   #��[ 65   $ 15q�6^   $��10,0,0,0q�6k   ._�57  "   �� .+�58  &   �� $��Total Items Sold��60   ���#6E6E6E$��13(�6]   $��Medium"�6k   �� 59  &   $��22(�6U   $
��Bold"�6c   $��0,5,0,0q�6u   ���#1A1A1A��60   �� *TotalItemsPurchased+6�   5:  #   5;     5<     5=     5>     �� 5@     $��1��6   #��[ 6&   $ 18q�6O   ._�5A     � + 5B     �� 5C     $��* �6,   �� 5D     $
��Auto �6,   .+�5G       -   5        3  Name$3 PurchaseRecordsDataGrid��5G  #   #��[ 5H  #   4   ColumnHeaderStyle#4 [ 5I  #   ��5J  #   �� *PurchaseRecords+5   Columns5 5K     0
  *System.Windows.Controls.DataGridTextColumn
  5L  "   ,  &System.Windows.Controls.DataGridColumn6   Header$6 
Invoice ID��65   7   Width5  /System.Windows.Controls.DataGridLengthConverter$	7 100 6I   1  +System.Windows.Controls.DataGridBoundColumn8   Binding8 6U   �� *	InvoiceId+
  5M  "   $6 Invoice No.��65   $	7 120 6J   8 6V   �� *InvoiceNumber+
  5N  "   $
6 Date��65   $	7 120 6C   8 6O   �� *InvoiceDate+9 �� StringFormat$9 d��
  5O  "   $6 Customer Name��65   $7 * 6L   8 6V   �� *CustomerName+
  5P  "   $6 Total Amount��65   $	7 120 6K   8 6W   �� *TotalAmount+$9 C0��4  .System.Windows.Controls.DataGridTemplateColumn  5Q  "   $6 Status��69   $	7 120 6I   :   CellTemplate: 5R  &   �� 5S  *   .R�5T  .   �� $ 4��6X   $	 5,2q�5U  5   $
��Left=�6C   $	��0,6q�6^   ��5T  5   �� *StatusColor+._�5V  2   �� 
�������$��12(�6g   ��6<   �� *Status+6g   5W  /   5X  +   5Z  #     5[  "   $6 Actions��69   $	7 180 6J   : 5\  &   �� 5]  *   .R�5^  .   �� $, 
Horizontal=�69   $	��0,4q�6R   .+�5_  2   �� #��[ 69   $
��10,5q�6e   $��0,0,5,0q�6t   .��5`  6   �� $, 
Horizontal=�6A   .+�5a  :   �� $	����6D   $��Segoe MDL2 Assets)�6T   $��0,0,5,0q�6s   �� 5b  :   $
��View��6D   5c  7   5d  3   �� 5e  2   #��[ 69   $
��10,5q�6g   .��5f  6   �� $, 
Horizontal=�6A   .+�5g  :   �� $	����6D   $��Segoe MDL2 Assets)�6T   $��0,0,5,0q�6s   �� 5h  :   $
��Edit��6D   5i  7   5j  3   5k  /   5l  +   5n  #   5p     �� 5r     $��1��6%   $, 
Horizontal=�62   $��Right=�6K   $��0,15,0,0q�6g   .+�5s     �� $��Previous��6%   #��[ 68   �� 5t     $��1��6%   #��[ 61   $��40��6]   �� 5u     $��2��6%   #��[ 61   $��40��6_   �� 5v     $��3��6%   #��[ 61   $��40��6_   �� 5w     $
��Next��6%   #��[ 64   5x     5y     5z     �� 5|     $��3��6   #��[ 6&   $ 18q�6O   $��0,15,0,0q�6\   ! 5}       5~     $ 10Q�6+   $ 1Q�6;   $	 0.1Q�6K   $ #000000��6Y   ._�5�     � + 5�     �� 5�     $
��Auto �6,   �� 5�     $	��250 �6,   .+�5�     �� $��0��6$   $��Monthly Sales Trend��61   $��18(�6L   $
��Bold"�6Z   ���#1A1A1A$��0,0,0,18q�6�   #  LiveCharts.Wpf.CartesianChart  5�     $��1��6-   &   LiveCharts.Wpf.Charts.Base.Chart;   AnimationsSpeed$; 0:0:0.5h�5�  -   <   	Hoverable$
< True��6G   $��0,10,0,0q�5�  -   =   Series= 5�  :   �� *MonthlyPurchaseSeries+>   AxisX> 5�  "     LiveCharts.Wpf.Axis  ?   Title$? Month��6+   @   
Foreground@ �#6E6E6EA   FontSize$A 12Q�5�  @   B   
FontWeight$B SemiBold"�6N   C   LabelsC 5�  9   �� *MonthlyPurchaseLabels+D   	SeparatorD 5�  &     LiveCharts.Wpf.Separator  5�  *   E   Step$E 1Q�68   ${�False��6A   5�  #   F   AxisYF 5�  "     $? Sales Amount (Rs.)��6+   @ �#6E6E6E$A 12Q�5�  @   $B SemiBold"�6N   D 5�  &     5�  *   $
{�True��68   G   StrokeDashArray$G 2R�6I   5�  #   5�     5�     5�     5�     5�     5�     5�     