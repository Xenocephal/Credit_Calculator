   M S B A M L   `   `   `  ����F  BCredit_Calc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Credit_CalcCredit_Calc  5   	       Credit_Calc.EnterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Credit_Calc     5   	   -   5          � Title$  Введите сумму��5   	   $	��140��5	   	   $	��210��6    � 
ResizeMode$ NoResize=�5
   	   $��Century Gothic)�5   	   $��14(�6%    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%V   '��       �� 5   
   " ��6   .�5      ��  � ��$ Center=�6;   5      5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      � 	 � Color$	 White��6   
 � Offset$	
 0.3Q�6-   � 5      $	 	#FF94C9FF��6   $
 1Q�61   5      .+�5   
   �� -   5        $��TextBox_Overpay��5      $
��5000��5      $��25��5      $	��100��5      $��5,5,0,0q�5      $
��Left=�5      $	��Top=�5      $��Center=�5       �� 5"   
   -   5        $��Ввод��5"      $
��Left=�5#      $��	110,5,0,0q�5$      $	��Top=�5%      $��25��5&      $��80��6   6(   �� 5(   
   -   5        $��ComboBox_PayType��5(      $
��Left=�5)      $��5,74,0,0q�5*      $	��Top=�5+      $	��185��5,      $��25��6    �� SelectedIndex$ 0��6+   �� 5.   
   $ ��Тип погашения:��6   $
��Left=�5/      $��	43,50,0,0q�50      $	��Top=�51      �� 53   
   -   5        $��CheckBox_FixPay��53      $��Полный платеж��54      $
��Left=�55      $��5,35,0,0q�56      $	��Top=�57      6+   59      5:      