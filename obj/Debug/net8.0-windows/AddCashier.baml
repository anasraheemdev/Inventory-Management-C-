   M S B A M L   `   `   `  ����B  >FinalDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:FinalDBFinalDB  5   	       FinalDB.AddCashier   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:FinalDB     5   	     � Title$  SULTANI POS - Add User��5   	   $	��720��6(   $
��1280��65    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         MenuButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value  PrimaryButtonStyle  SecondaryButtonStyle �� BasedOn  CardBorderStyle3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Opacity   Color  FormControlStyle  FormLabelStyle  InputBoxStyle ��Name  ComboBoxStyle��%t  &	        &	 i    &	 �    7  &	 �    &	 �    &	 E    &	 �    7  &	 .
    7  �� 5   
   " ��6(   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$ 40��6'   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 15,0,0,0q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   $ 6��6�   ._�5      �� #��z��6/   $��Center=�6r   5      5      5       5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5      ��  � �� �#3672CF63   �� 5       � ��
 �����63   5       5"      �� 5$   
   " ��6+   .�5%      ��  � �� �#1E5AAF6+   �� 5&       � ��
 �����6+   �� 5'       � ��$ 0q�60   �� 5(       � ��$
 15,8q�6(   �� 5)       � ��$ 0,0,10,0q�6'   �� 5*       � �� 5+      �� 5,      " ��6&   .R�5-      �� #��z��6!   $ 6��5.   !   #��z��5/   !   ._�50      �� $��Center=�6/   $��Center=�51   /   #��z��52   /   53      54      56       57      P� 58      	 �@J�IsMouseOver$

 True��61   . �59      ��  � �� �#3672CF63   5:      5<      �� 5>   
   " ��6-   8   .�5?      ��  � �� �#E0E0E06+   �� 5@       � �� �#1A1A1A6+    5A      P� 5B      	 �@J�IsMouseOver$

 True��61   . �5C      ��  � �� �#D0D0D063   5D      5F      �� 5H   
   " ��6(   .�5I      ��  � ��
 �����6+   �� 5J       � �� �#E0E0E06,   �� 5K       � ��$ 1q�60   �� 5L       �@��CornerRadius$ 10��6-   �� 5M       �@J�Effect 5N        5O      $ 10Q�6'   $ 1Q�67   $	 0.1Q�6G   $ #000000��6U   5Q      5R      �� 5T   
   " ��6)   .�5U      ��  � ��$ 32��6'   �� 5V       � ��$ 0q�6'   5W      �� 5Y   
   " ��6'   .�5Z      ��  � �� �#6E6E6E6+   �� 5[       � ��$ 0,0,0,5q�6'   �� 5\       � ��$ 12(�6)   5]      �� 5_   
   " ��6&   8   .�5`      ��  � ��
 �����6+   �� 5a       � �� �#E0E0E06,   �� 5b       � ��$ 1q�60   �� 5c       � ��$
 10,5q�6(   �� 5d       � ��$ Center=�69   �� 5e       � �� 5f      �� 5g      " ��6&   .R�5h      �� #��z��6!   #��z��5i   !   #��z��5j   !   $ 6��5k   !   ._�5l      �� $ PART_ContentHost��6+   #��z��5m   +   #��z��5n   +   5o      5p      5r       5s      P� 5t      	 �@J�	IsFocused$

 True��6/   . �5u      ��  � �� �#1E5AAF64   5v      5x      �� 5z   
   " ��6&   8   .�5{      ��  � ��
 �����6+   �� 5|       � �� �#E0E0E06,   �� 5}       � ��$ 1q�60   �� 5~       � ��$
 10,5q�6(   �� 5       � ��$ Center=�69   5�      5�      .��5�      �  � ColumnDefinitions 5�   
   �� 5�      $	��220 �6   �� 5�      $��* �6   .+�5�   
   �� ���#1E5AAF���#1648A0$��0,0,1,0q�6<   ._�5�      �  � RowDefinitions 5�      �� 5�      $��70 �6$   �� 5�      $��* �6$   �� 5�      $
��Auto �6$   .+�5�      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��20,0,0,0q�6C   $��Center=�6U   .+�5�      �� $��SULTA��6    $��22(�6-   $
��Bold"�6;   
�������6M   �� 5�      $��NI��6    $��22(�6*   $
��Bold"�68   ���#3CEFFF6J   �� 5�      $
�� POS��6    $��16(�6,   ���#9DC3F5$��Bottom=�6O   $��5,0,0,2q�6j   5�      �� 5�      $��1��6   $
��Auto=�6,   .��5�      �� $��
10,20,10,0q�6!   .+�5�      �� -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��	Dashboard��6,   $��SemiBold"�6=   5�      5�      �� 5�      $��CASHIER��6$   $��	15,20,0,5q�63   ���#9DC3F5$��12(�6[   $��SemiBold"�6i   �� 5�      -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Make Invoice��6,   5�      5�      �� 5�      -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Transaction��6,   5�      5�      �� 5�      $��	INVENTORY��6$   $��	15,20,0,5q�65   ���#9DC3F5$��12(�6]   $��SemiBold"�6k   �� 5�      -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Add Item��6,   5�      5�      �� 5�      -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Purchase Order��6,   5�      5�      �� 5�      -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Purchase Record��6,   5�      5�      �� 5�      $��USERS��6$   $��	15,20,0,5q�61   ���#9DC3F5$��12(�6Y   $��SemiBold"�6g   �� 5�      #��[  6!   ���#3672CF.��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Add User��6,   5�      5�      �� 5�      -   5        #��[  5�   !   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,10,0q�6[   �� 5�   "   $��Administrators��6,   5�      5�      9� 5�      $��More Options��6#   ���#9DC3F5$��	10,10,0,0q�6N   
������ $��0q�5�   <   .��5�      �� .+�5�   "   �� -   5        #��[  5�   )   .��5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $	����64   $��Segoe MDL2 Assets)�6D   $��0,0,10,0q�6c   �� 5�   *   $��User Manager��64   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $��2��6   ���#174B92���#144283$��0,1,0,0q�6Q    �� Padding$ 15,12q�6k   ._�5�      �� $ 
Horizontal=�6!   .+�5�      �� $��36��6!   $��36��6,   ���#3CEFFF$ 18��6M   ._�5�      �� $��AR��6(   ���#0A2D5E$��Center=�6G   $��Center=�6d   $
��Bold"�6   5�      �� 5�      $��10,0,0,0q�6%   .+�5�      �� $��Anas Raheem��6(   $��SemiBold"�6;   $��14(�6Q   
�������6_   �� 5�      $��Administrator��6(   $��11(�6=   ���#9DC3F56K   5�      5�      5�      5�      5�      � 5�   
   $��1��6   ���#F6F9FC 5�      �� 5�      $��70 �6    �� 5�      $��* �6    .+�5�      �� 
����������#E0E0E0$��0,0,0,1q�6>   ._�5�      �  5�      �� 5�      $��* �6+   �� 5�      $
��Auto �6+   .+�5�      �� $��ADD NEW USER��6    $��22(�64   $
��Bold"�6B   $��Center=�6T   $��25,0,0,0q�6o   ���#1E5AAF6�   �� 5�      $��1��6!   $ 
Horizontal=�61   $��0,0,25,0q�6J   .+�5�      �� -	   5        #��[ 5�   !   $��40��6M   .��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $	����6,   $��Segoe MDL2 Assets)�6<   $��0,0,8,0q�6[   �� 5�   "   $��View All Users��6,   5      5     5     5     5     � 5     $��1��6   $��25,15,25,25q�6    .+�5     �� #��[ 6   $ 20q�6B   ._�5     �  5	     �� 5
     $
��Auto �6,   �� 5     $��* �6,   �� 5     $
��Auto �6,   .+�5     �� $��0��6%   $��0,0,0,20q�62   .+�5     �� $��User Information��6(   $��18(�6@   $��SemiBold"�6N   ���#1E5AAF6d   �� 5     $3��-Please fill all required fields marked with *��6(   $��12(�6]   ���#6E6E6E$��0,5,0,0q�6�   5     �� 5     $��1��6'   $
��Auto=�64   .��5     �  5  "   �� 5  &   $��* �67   �� 5  &   $��* �67   .+�5  "   �� $��0��6-   $��0,0,15,0q�6=   .+�5  &   �� $��0,0,0,20q�61   .+�5  *   �� $��Profile Image��64   #��[ 6I   � 5  *   .+�5  .   �� $	��100��65   $	��100��6A   ���#F0F5FF���#D8E3F4$��1q�5      $ 50��6)   $��0,10,0,0q�6;   $
}�True��5!     ._�5"  2   � .+�5#  6   �� -
   5         ��Name$ 
imgProfile��5#  <   $��UniformToFill=�6P   $��Center=�6h   $��Center=�6�    �� BitmapScalingMode$ HighQuality=�5$     $y�	Collapsed=�6J   �� 5%  6   -   5         ��Name$ txtProfileIcon��5%  @   $	����6X   $��Segoe MDL2 Assets)�6h   $��36(�6�   $��Center=�5&      $��Center=�6=   ���#1E5AAF$y�Visible=�5'      5(  3   5)  /   �� 5*  .   -   5         ��Name$ btnSelectImage��5*  5   #��[ 6M   $��32��6y   $��32��6�   $
��Left=�5+     $��Bottom=�60   $��75,0,0,0q�6K   $��0q�6]   .��5-  2   �� $	����6<   $��Segoe MDL2 Assets)�6L   5.  /   5/  +   50  '   �� 51  &   $��0,0,0,15q�61   .+�52  *   �� $��	User ID *��64   #��[ 6E   �� 53  *   -   5         ��Name$ 	txtUserId��53  2   #��[ 6E   $��36��6l   54  '   �� 56  &   $��0,0,0,15q�61   .+�57  *   �� $��Full Name *��64   #��[ 6G   �� 58  *   -   5        $ txtFullName��58  2   #��[ 6G   $��36��6n   59  '   �� 5;  &   $��0,0,0,15q�61   .+�5<  *   �� $��Email Address *��64   #��[ 6K   �� 5=  *   -   5        $ txtEmailAddress��5=  2   #��[ 6K   $��36��6r   5>  '   �� 5@  &   $��0,0,0,15q�61   .+�5A  *   �� $��Phone Number *��64   #��[ 6J   �� 5B  *   -   5        $ txtPhoneNumber��5B  2   #��[ 6J   $��36��6q   5C  '   �� 5E  &   $��0,0,0,15q�61   .+�5F  *   �� $��
Username *��64   #��[ 6F   �� 5G  *   -   5        $ txtUsername��5G  2   #��[ 6G   $��36��6n   5H  '   5I  #   �� 5K  "   $��1��6-   $��15,0,0,0q�6=   .+�5L  &   �� $��0,0,0,15q�61   .+�5M  *   �� $��User Role *��64   #��[ 6G   �� 5N  *   -   5         ��Name$ cmbUserRole��5N  3   #��[ 6H   $��36��6o   .@�5O  .   �� $��Select Role��6;    �� 
IsSelected$
 True��6Q   �� 5P  .   $��Cashier��6;   �� 5Q  .   $��Admin��6;   5R  +   5S  '   �� 5U  &   $��0,0,0,15q�61   .+�5V  *   �� $��Gender��64   #��[ 6B   �� 5W  *   -   5        $ 	cmbGender��5W  3   #��[ 6F   $��36��6m   .@�5X  .   �� $��Select Gender��6;   $
 True��6S   �� 5Y  .   $
��Male��6;   �� 5Z  .   $��Female��6;   �� 5[  .   $��Other��6;   5\  +   5]  '   �� 5_  &   $��0,0,0,15q�61   .+�5`  *   �� $��Date of Birth��64   #��[ 6I   (  "System.Windows.Controls.DatePicker  5a  *   -   5          Name$ dpDateOfBirth��5a  5   $��36��6L   $
��10,5q�6X   ���#E0E0E0$��1q�6}    5b  .   ��%^   '��       �� 5c  2   " ��68   .�5d  6   ��  �@��CornerRadius$ 6��6U   5e  3   5f  /   5g  +   5h  '   �� 5j  &   $��0,0,0,15q�61   .+�5k  *   �� $��Address��64   #��[ 6C   �� 5l  *   -   5        $ 
txtAddress��5l  2   #��[ 6F   $��80��6m    �� TextWrapping$
 Wrap=�5m  2    �� AcceptsReturn$
 True��6F   $	��Top=�5n  2   5o  '   �� 5q  &   $��0,0,0,15q�61   .+�5r  *   �� $��
Password *��64   #��[ 6F   G� 5s  *   -   5         G�Name$ pwdPassword��5s  6   $��36��6K   $
��10,5q�6W   ���#E0E0E0$��1q�6|   $��Center=�5t  6    5u  .   ��%^   '��       �� 5v  2   " ��68   .�5w  6   ��  �@��CornerRadius$ 6��6U   5x  3   5y  /   5z  +   5{  '   �� 5}  &   $��0,0,0,15q�61   .+�5~  *   �� $��Confirm Password *��64   #��[ 6N   G� 5  *   -   5        $ pwdConfirmPassword��5  6   $��36��6R   $
��10,5q�6^   ���#E0E0E0$��1q�6�   $��Center=�5�  6    5�  .   ��%^   '��       �� 5�  2   " ��68   .�5�  6   ��  �@��CornerRadius$ 6��6U   5�  3   5�  /   5�  +   5�  '   �� 5�  &   $��0,0,0,15q�61   .+�5�  *   �� $��Status *��64   #��[ 6D   �� 5�  *   -   5        $ 	cmbStatus��5�  3   #��[ 6F   $��36��6m   .@�5�  .   �� $��Active��6;   $
 True��6L   �� 5�  .   $��Inactive��6;   �� 5�  .   $��	Suspended��6;   5�  +   5�  '   5�  #   5�     5�     �� 5�     $��2��6%   $ 
Horizontal=�62   $��Right=�6K   $��0,20,0,0q�6g   .+�5�     �� -   5        #��[ 5�  %   $��Cancel��6S   $	��120��6d   $��40��6p   $��0,0,15,0q�6|   6�   �� 5�     -   5        #��[ 5�  %   $	��120��6Q   $��40��6]   .��5�  "   �� $ 
Horizontal=�6-   .+�5�  &   �� $	����60   $��Segoe MDL2 Assets)�6@   $��0,0,8,0q�6_   �� 5�  &   $
��Save��60   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     