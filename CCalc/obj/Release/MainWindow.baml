   M S B A M L   `   `   `  ���� F  BCredit_Calc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Credit_CalcCredit_Calc      Credit_Calc.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:Credit_Calc       � Title$  Credit Calc��$	��600��$	��700�� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� 
TargetType �� Property �� Value��%b   '��       '�� '     �� " ��.���  � ��$ Center=��� " ��.���  � ��$ Center=�.��� .+��� -   $��TextBox_CreditCost��$
��Left=�$��	10,10,0,0q�$��2468000�� �� TextWrapping$
 Wrap=�$	��Top=�$��80��$��25��$��1���� -   $��TextBox_Percent��$
��Left=�$��	10,40,0,0q�$
��9,00��$
 Wrap=�$	��Top=�$��80��$��25��$��2���� -   $��TextBox_MonthCount��$
��Left=�$��	10,70,0,0q�$	��180��$
 Wrap=�$	��Top=�$��80��$��25��$��3���� $��Сумма кредита��$
��Left=�$��	95,10,0,0q�$	��Top=��� $'��!Процентная ставка��$
��Left=�$��	95,41,0,0q�$	��Top=��� $)��#Количество месяцев��$
��Left=�$��	95,72,0,0q�$	��Top=��� -   $��	ListView1��$��	0,100,0,0q�$��2�� � ContextMenu �� .@�m� -   $��Ввести��m� -   $��Очистить��m� -   $*��$Сменить тип платежа�� �� View �� .P��� 	 �� Width$	 50��
 �� DisplayMemberBinding
 ��  �� Path$ MonthNum�.��
Месяц�� $		 100��
 �� $	 Pay� �� StringFormat$ {0:F2}��.��Платеж�� $		 120��
 �� $ Percents�$ {0:F2}��.��Проценты�� $		 150��
 �� $
 Last�$ {0:F2}��.��Остаток долга�� $		 120��
 �� $ OverPay�$ {0:F2}��.��Досрочно�� $		 110��
 �� $ PayType�.��Тип погашения�� -   $��Label_CreditCost��$5��/Полная стоимость кредита:��$
��Left=�$��
238,10,0,0q�$	��Top=��� -	   $��Label_Overpay��$��Переплата:��$
��Left=�$��
238,41,0,0q�$	��Top=��� -
   $��Label_Profit��$��Выгода:��$
��Left=�$��
344,72,0,0q�$	��Top=��� -   $��Вычислить��$��25��$��80��$��
238,70,0,0q�$	��Top=�$
��Left=�$��4��