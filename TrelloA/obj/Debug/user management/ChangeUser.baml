   M S B A M L   `   `   `  ����B  >TrelloA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TrelloATrelloA  5   	       TrelloA.ChangeUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TrelloA     5   	     � Title$  
ChangeUser��5   	   $	��450��6   $	��800��6)   .��5	      �� .+�5
   
   �� $��25��6   
�������
������$��DemiBold"�6Y   .��6o   RPвведите данные для поиска (id/username/firstname/lastname)6�   �� 5   
   -   5         ��Name$ 
findInfoTB��5      6(   �� 5   
   -   5        $��25��5      
�������.��6Y   '%вывод пользователей6n   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	usersGrid��5   �   $��1��6   $
��Left=�6    $	��250��6<   $	��Top=�6I   $
��auto��6a      AutoGenerateColumns . 5      �� 5   
   -   5        $��25��5      
�������.��6O   '%применить изменения6d   5      5      