   M S B A M L   `   `   `  ����  ControlWorks$    ControlWorks.U_LancamentoDados   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        .��5      �� .+�5   
   ��   �� Orientation$  
Horizontal=�6   $��2q�6.   .+�5	      �� $��Pesquisar: ��6   $��0q�6*   �� 5
      -   5         ��Name$ tbPesquisar��5
      $	��500��6+    �� 	MaxLength$ 60��67   $��20��6F   6R   5      �� 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLancamentos��5   (   $��0 2 0 0q�6      AutoGenerateColumns$ False��6F      AlternatingRowBackground
 �����   CanUserAddRows$ False��6�   ��6�   ��  �� Path$ L_Treino� �� UpdateSourceTrigger$ PropertyChanged=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly$

 True��6D      Header$ Código��6V      MinWidth$ 80Q�6f      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Codigo+6t     5      $

 True��6D   $ Título��6V   $	 150Q�6f   $ * 6u    6)   �� *Titulo+6u     5      $

 True��6L   $ 	Treinador��6^   $	 250Q�6q   $ * 6�    6)   �� *Treinador.Nome+6�     5      $

 True��6I   $ Atleta��6[   $	 250Q�6k   $ * 6z    6)   �� *Atleta.Nome+6z   5      5      5      5      