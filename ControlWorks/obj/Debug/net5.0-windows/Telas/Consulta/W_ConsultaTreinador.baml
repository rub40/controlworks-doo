   M S B A M L   `   `   `  ����  ControlWorks&     ControlWorks.W_ConsultaTreinador   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  W_ConsultaTreinadorAtleta��5   	   $	��450��6+   $	��800��68    � WindowStartupLocation$ CenterScreen=�6D   .��5      ��  �� Orientation$ Vertical=�6   .+�5	   
   �� .+�5
      �� $��Consulta de Treinador��6   $��Center=�65   5      �� 5   
   $ 
Horizontal=�6   $��2q�6.   .+�5      �� $��Pesquisar: ��6   $��0q�6*   �� 5      -   5         ��Name$ tbPesquisar��5      $	��500��6+   $��20��67    �� 	MaxLength$ 60��6C   6R   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridTreinador��5         AutoGenerateColumns$ False��6,      AlternatingRowBackground
 �����   CanUserAddRows$ False��6n   ��6�   ��  �� Path$ L_Treinador�	 �� UpdateSourceTrigger$	 PropertyChanged=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6@      Header$ Código��6R      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Codigo+6b     5      $
 True��6=   $	 CPF��6O   $	 180 6\    6%   �� *Cpf+6\     5      $
 True��6>   $
 Nome��6P   $	 350 6^    6%   �� *Nome+6^   5      5      5      