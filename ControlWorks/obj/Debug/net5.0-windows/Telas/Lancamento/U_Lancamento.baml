   M S B A M L   `   `   `  ����G  CControlWorks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ControlWorksControlWorks  5          ControlWorks.U_Lancamento   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3controlworksclr-namespace:ControlWorks     5      @
extensions)using:Microsoft.Toolkit.Uwp.UI.Extensions     5      -   5        $��5q�5        � 	Resources  5	      '   !ControlWorks.ConversorTrueVisible   converterTrue(   "ControlWorks.ConversorFalseVisible  converterFalse�� 5
   
   %:   &	        &	        5      60     5      61   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� .+�5      �� $��Código:��6   $��0q�6*   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ tbCodigo��5      $��20��60   $	��140��6<   $
��Left=�6H   ��6c   ��  �� Path$ CurrentTreino.Codigo� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5      �� 5      .+�5      �� $��Data:��6   $��0q�6(   �� 5      $ 
Horizontal=�6   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ tbDataTreino��5   !   $��23��67   $	��140��6C   $
��Left=�6O      SelectedDate 6j   �� $ CurrentTreino.Data�$ PropertyChanged=�5       5!      �� 5"      .+�5#      �� $��Título:��6   $��0q�6*   �� 5$      $ 
Horizontal=�6   .+�5%      �� -   5        $ tbTitulo��5%      $��20��60   $	��350��6<   $
��Left=�6H   ��6c   �� $ CurrentTreino.Titulo�$ PropertyChanged=�5&      5'      �� 5(      .+�5)      �� $��
Treinador:��6   $��0q�6-   �� 5*      $ 
Horizontal=�6   .+�5+      �� -   5        $ tbCodigoTreinador��5+      $��20��69   $	��140��6E   $
��Left=�6Q   ��6l   �� $$ CurrentTreino.Treinador.Codigo�$ PropertyChanged=�6�   �� 5,      -   5        $��5 0 0 0q�5,       $	����61   $��Segoe MDL2 Assets)�6A   $��15��6`   $��18��6k   $��14(�6x   $|�False��6�   6�   �� 5-      $��5 0 0 0q�6x   ��6    �� $" CurrentTreino.Treinador.Nome�$ PropertyChanged=�6x   5.      5/      �� 50      .+�51      �� $��Atleta:��6   $��0q�6*   �� 52      $ 
Horizontal=�6   .+�53      �� -   5        $ tbCodigoAtleta��53      $	��140��66   $��20��6B    �� 	MaxLength$ 60��6N   $
��Left=�6]   ��6x   �� $! CurrentTreino.Atleta.Codigo�$ PropertyChanged=�6�   �� 54      -   5        $��5 0 0 0q�54       $	����61   $��Segoe MDL2 Assets)�6A   $��15��6`   $��18��6k   $��14(�6x   $|�False��6�   6�   �� 55      $��5 0 0 0q�6u   ��6    �� $ CurrentTreino.Atleta.Nome�$ PropertyChanged=�6u   56      57      �� 58      $ Vertical=�6   .+�59      �� $ 
Horizontal=�6   .+�5:      �� $ Vertical=�6!   .+�5;      �� $��Código exercicio:��6    $��0q�6<   $��0 5 0 0q�6H   �� 5<      $ 
Horizontal=�6%   .+�5=      �� -	   5        $ tbCodigoExercicio��5=   &   $	��140��6A   $ 60��6M   $��20��6\   $
��Left=�6h   ��6�   �� $ CurrentExercicio.Codigo�$ PropertyChanged=�6�   �� 5>      -
   5        $��5 0 0 0q�5>   (   $	����69   $��Segoe MDL2 Assets)�6I   $��15��6h   $��18��6s   $��14(�6�   $|�False��6�   6�   5?      5@      �� 5A      $ Vertical=�6!   $��5 0 0 0q�68   .+�5B      �� $��Descrição:��6    $��0q�65   $��0 5 0 0q�6A   �� 5C      $ 
Horizontal=�6%   .+�5D      �� $	��250��6'   $ 60��63   $��20��6B   $
��Left=�6N   $|�False��6i   ${�False��6{   ��6�   �� $  CurrentExercicio.Descricao�$ PropertyChanged=�5E      5F      �� 5G      $ Vertical=�6!   $��5 0 0 0q�68   .+�5H      �� $��Tipo:��6    $��0q�60   $��0 5 0 0q�6<   �� 5I      $ 
Horizontal=�6%   .+�5J      �� $	��100��6'   $ 60��63   $��20��6B   $
��Left=�6N   $|�False��6i   ${�False��6{   ��6�   �� $+ %CurrentExercicio.TipoTreino.Descricao�$ PropertyChanged=�5K      5L      �� 5M      $ Vertical=�6!   $��2 0 0 0q�68   .+�5N      �� $��Tempo (segundos):��6    $��0q�6<   $��0 5 0 0q�6H   ${�False��6Y   �� 5O      $ 
Horizontal=�6%   .+�5P      �� -   5        $ tbTempoExercicio��5P   &   $	��110��6@   $ 60��6L   $
��Left=�6[   ��6v   �� $ CurrentExercicio.Tempo�$ PropertyChanged=�{�6�   �� $ CurrentExercicio.IsTempo�$ PropertyChanged=��� 5Q      -   5        $��2 0 0 0q�5Q   %   $	��100��66   $��20��6B   $��	Adicionar��6N   $��SemiBold"�6b   6x   5R      5S      5T      �� 5U      .+�5V      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 dgExercicios��5V   ,   $	��200��6   $��0 2 0 0q�6B   $
   HorizontalScrollBarVisibility$

 Auto=�6S      AutoGenerateColumns$ False��6x      AlternatingRowBackground
 �����   CanUserAddRows$ False��6�   ��6�   �� $ CurrentTreino.L_Exercicio�$ PropertyChanged=�   Columns 5W      0  *System.Windows.Controls.DataGridTextColumn  5X      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6L      Header$ Código��6^      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Codigo+6n     5Y      $
 True��6O   $ 	Descricao��6a   $	 250 6t    61   �� *	Descricao+6t     5Z      $
 True��6Z   $ 	Descricao��6l   $	 100 6    61   �� *TipoTreino.Descricao+6     5[      $
 True��6K   $ Tempo��6]   $	 100 6l    61   �� *Tempo+6l   5]      5^      5_      �� 5`      $
��Left=�6   .+�5a      �� $�� ��6   $��0q�6$   �� 5b      $ 
Horizontal=�6   .+�5c      �� -   5        $	��130��5c      $��20��6)   $��Salvar��65   $��SemiBold"�6F   6\   5d      5e      �� 5f      $�� ��6   $��0q�6    �� 5g      �� 5h      $��Treinos existentes:��6   $��16(�62   $��SemiBold"�6@   $��0q�6V   5i      �� 5j   
   $��1��6   �� 5k   
   $��2��6   ��6&   �� $ 	TelaDados�$ PropertyChanged=�5l      5m      