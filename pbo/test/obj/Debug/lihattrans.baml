   M S B A M L   `   `   `  ����?  ;test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:testtest  5   	       test.lihattrans   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:test     5   	   -   5          �Name$  lihat_transaksi��5   	    � Title$ 	lihatakun��5   	   $	��756��6   $
��1050��6(    � WindowStyle$ ThreeDBorderWindow=�65    � WindowStartupLocation$ CenterScreen=�6V   .��5	      �  J� IsHitTestVisible . ���	#FFC7C7C7 � ColumnDefinitions 5
   
   �� 5      $
��155* �6   �� 5      $	��25* �6   �� 5      $	��27* �6   �� 5      $	��85* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ GridLT��5      $
��Left=�6#   $��
10,28,0,28q�6>   $	��852��6R   $��4��6^      Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Delete��6)   0  *System.Windows.Controls.DataGridTextColumn  5      $ 	Id Produk��6%   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 200 6g      FontSize$ 16Q�6s   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *
IdBarang+6s     5      $ Nama Produk��6%   	 . $	
 200 6L   $ 16Q�6X     5      $ Jumlah��6%   	 . $	
 150 6h   $ 16Q�6t    6G   �� *JumlahBarang+6t     5      $ Harga��6%   	 . $	
 150 6f   $ 16Q�6r    6F   �� *HargaBarang+6r     5      $ Diskon��6%   	 . $	
 150 6G   5      �� 5   
   -   5         ��Name$ hapuslt��5      $��Hapus��6"   $
��Left=�62   $��
134,26,0,0q�6M   $	��Top=�6a   $	��156��6y   $��44��6�   $��3��6�   $��18(�6�   ���	#FF3D1A55$��Cabin)�6�   
�������6�   5      5      