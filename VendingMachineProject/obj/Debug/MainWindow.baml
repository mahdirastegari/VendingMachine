   M S B A M L   `   `   `  ����P  LVendingMachineProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VendingMachineProjectVendingMachineProject  5   	   &     VendingMachineProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:VendingMachineProject     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStyle$
  None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Title$ 
MainWindow��5   	   $	��460��6   $	��600��6)    � DataContext 5   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      � $��
25,5,25,25q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��E-Corp Vending Machine��6   $��0��63   $��35(�6@   �� 5   
   $��1��6   $��2��6"    ) %MaterialDesignDarkSeparatorBackground#��[ 6-   $��-20,10,-20,20q�6k   �� 5   
   $��2��6   ��6&   �� *CurrentView+9� 5   
   $��0��6   $��3��6     9� ExpandDirection$
 Down=�61   $��Right=�6H   ��5      � 5      .+�5      �� $��Eliot A.��6    $��25(�60   $��Center=�6>   6[   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$
 User=�6.   $��40��6:   $��40��6E   5      .��5       ��   MaterialDesignShadowBrush#��[ 6   $	��150��6Q   .+�5!      �� 
���������6-   �� *SignOutCommand+.��5"      � .+�5#        $ SignOut=�62   $��Center=�6B   �� 5$      $��Sign out��6$   $��Center=�64   5%      5&      �� 5'      
���������6-   �� *ExitCommand+.��5(      � .+�5)        $ 	ExitToApp=�62   $��Center=�6C   �� 5*      $
��Exit��6$   $��Center=�60   5+      5,      5-      5.      5/      50      