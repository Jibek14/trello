   M S B A M L   `   `   `  ����B  >TrelloA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TrelloA.user_managementTrelloA.user_management  5   	   (    "TrelloA.user_management.DeleteUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:TrelloA.user_management     5   	   -   5          � Title$  
DeleteUser��5   	   $	��450��6   $	��800��6)   .��5	      �� .+�5
   
   �� $��25��6   
�������
������$��DemiBold"�6Y   .��6o   RPвведите данные для поиска (id/username/firstname/lastname)6�   �� 5   
   -   5         ��Name$ 
findInfoTB��5      6(   �� 5   
   -   5        $��25��5      
�������.��6Y   ,*поиск пользователя(-ей)6r   � 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	gridPosts��5      ��6*   �� *	dataTable+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Delete��6-      CellTemplate 5      �� 5      .R�5   "   ��  ��Name$ delete��6)   -   5        $��Delete��5   9   5   #   5      5      5      5      5      5      