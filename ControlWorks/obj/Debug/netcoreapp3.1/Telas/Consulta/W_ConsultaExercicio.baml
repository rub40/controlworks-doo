   M S B A M L   `   `   `  ����  ControlWorks&     ControlWorks.W_ConsultaExercicio   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Consulta de Exercicios��5   	   $	��450��6(   $	��800��65    � WindowStartupLocation$ CenterScreen=�6A   .��5      ��  �� Orientation$ Vertical=�6   .+�5	   
   �� .+�5
      �� $��Consulta de Atletas��6   $��Center=�63   5      �� 5   
   .+�5      �� $ 
Horizontal=�6   $��2q�62   .+�5      �� $��Pesquisar: ��6   $��0q�6.   �� 5      -   5         ��Name$ tbPesquisar��5      $��20��6/   $	��500��6;    �� 	MaxLength$ 60��6G   6V   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridExercicio��5         AutoGenerateColumns$ False��6,      AlternatingRowBackground
 �����   CanUserAddRows$ False��6n   ��6�   ��  �� Path$ L_Exercicio�	 �� UpdateSourceTrigger$	 PropertyChanged=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6@      Header$ Código��6R      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Codigo+6b     5      $
 True��6C   $	 CPF��6U   $	 180 6b    6%   �� *	Descricao+6b     5      $
 True��6N   $
 Nome��6`   $	 350 6n    6%   �� *TipoTreino.Descricao+6n   5      5      5      