   M S B A M L   `   `   `  ����?  ;bank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:bankbank  5   	       bank.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   localclr-namespace:bank  5   	     � Title$  Main Window��5	   	   $	��550��6   $	��800��6+    � 
ResizeMode$ NoResize=�67    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers	 P� Property
 P� Value   
ButtonText  
ButtonPlus 
 Footer  	LabelText��%:  '��       &	  ]    &	 �    &	 �    &	 H    �� 5   
   " ��6   .�5      ��  � ��$	 150��6&   �� 5       � ��$	 150��6'   �� 5       � ��
 �   �6,   �� 5       � ��$ 2q�60   �� 5       � �� �#4da3376+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 75��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5      	 �@J�IsMouseOver$

 True��61   . �5      ��  � �� �#3e822c63   �� 5        �@�Cursor$
 Hand��6/   5!      5#      �� 5$   
   " ��6   .�5%      ��  � ��
 �����6+   �� 5&       � ��$ 75(�6)   �� 5'       � ��$ Center=�62   5(      �� 5)   
   " ��6#   .�5*      ��  � ��$ 0,5,0,0q�6'   �� 5+       � ��
 �����6+   �� 5,       � ��$ 75(�6)   �� 5-       � ��$ Center=�62   5.      �� 5/   
   " ��6   .�50      ��  � ��$ Center=�64   �� 51       � ��$ 15(�6)   �� 52       � ��$
 Bold"�6+   53      �� 54   
   " ��6"   .�55      ��  � ��$ 20(�6)   �� 56       � ��$ Center=�64   �� 57       � ��$
 Bold"�6+   �� 58       � ��$ 0,0,0,10q�6'   59      5:      .��5;      �  � RowDefinitions 5<   
   �� 5=      $��* �6   �� 5>      $��* �6   �� 5?      $��30 �6   .+�5A   
   �� .+�5B      �� #��[ 6   Login5D      �� 5E   
   -   5        .��5F      �� !  FontAwesome.WPF.FontAwesome  5G         Icon$
 User=�6   #��[  6)   5H      5I      5J      �� 5K   
   $��1��6   .+�5L      �� #��[ 6   Create Account5N      �� 5O   
   -   5        .��5P      ��   5Q      $
 Plus=�6   #��[ 6)   5R      5S      5T      �� 5U   
   $��2��6   #��[ 6!   1/Made by: Sebastian Kopieć & Adrian Zabrzeński5W       � 5X   
   -   5        $��	MainFrame��5X        � NavigationUIVisibility$ Hidden=�6!   $��Stretch=�6A   $��Stretch=�6_   $��3��6{   5Y      5Z      