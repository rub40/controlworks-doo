   M S B A M L   `   `   `  ����  ControlWorks#    ControlWorks.U_TreinadorDados   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      �� .+�5   
   ��   �� Orientation$  
Horizontal=�6   $��2q�6.   .+�5	      �� $��Pesquisar: ��6   $��0q�6*   �� 5
      -   5         ��Name$ tbPesquisar��5
      $��20��6+   $	��500��67    �� 	MaxLength$ 60��6C   6R   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridTreinador��5         AutoGenerateColumns$ False��6,      AlternatingRowBackground
 �����   CanUserAddRows$ False��6n   ��6�   ��  �� Path$ L_Treinador� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly$
	 True��6@   
   Header$
 Código��6R      MinWidth$	 100Q�6b      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Codigo+6q     5      $
	 True��6=   $	
 CPF��6O   $	 150Q�6\   $ * 6l    6%   �� *Cpf+6l     5      $
	 True��6>   $

 Nome��6P   $	 200Q�6^   $ * 6m    6%   �� *Nome+6m     5      $
	 True��6B   $
 Endereco��6T   $	 200Q�6f   $ * 6u    6%   �� *
Endereco+6u     5      $
	 True��6B   $
 Telefone��6T   $	 200Q�6f   $ * 6u    6%   �� *
Telefone+6u   5      5      5      