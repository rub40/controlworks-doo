   M S B A M L   `   `   `  ����G  CControlWorks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ControlWorksControlWorks  5          ControlWorks.U_Lancamento   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3controlworksclr-namespace:ControlWorks     5      -   5        $��5q�5        � 	Resources  5      '   !ControlWorks.ConversorTrueVisible   converterTrue(   "ControlWorks.ConversorFalseVisible  converterFalse�� 5	   
   %:   &	        &	        5
      60     5      61   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   .+�5      �� .+�5      �� $��Código:��6   $��0q�6*   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ tbCodigo��5      $��20��60   $	��130��6<   $
��Left=�6H   ��6c   ��  �� Path$ CurrentTreino.Codigo� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5      �� 5      .+�5      �� $��Título:��6   $��0q�6*   �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $ tbTitulo��5      $��20��60   $	��350��6<   $
��Left=�6H   ��6c   �� $ CurrentTreino.Titulo�$ PropertyChanged=�5      5       �� 5!      .+�5"      �� $��
Treinador:��6   $��0q�6-   �� 5#      $ 
Horizontal=�6   .+�5$      �� -   5        $ tbCodigoTreinador��5$      $��20��69   $	��130��6E   $
��Left=�6Q   ��6l   �� $$ CurrentTreino.Treinador.Codigo�$ PropertyChanged=�6�   �� 5%      -   5        $��5 0 0 0q�5%       $	����61   $��Segoe MDL2 Assets)�6A   $��15��6`   $��18��6k   $��14(�6x   $|�False��6�   6�   �� 5&      $��5 0 0 0q�6x   ��6    �� $" CurrentTreino.Treinador.Nome�$ PropertyChanged=�6x   5'      5(      �� 5)      .+�5*      �� $��Atleta:��6   $��0q�6*   �� 5+      $ 
Horizontal=�6   .+�5,      �� -   5        $ tbCodigoAtleta��5,      $	��130��66   $��20��6B    �� 	MaxLength$ 60��6N   $
��Left=�6]   ��6x   �� $! CurrentTreino.Atleta.Codigo�$ PropertyChanged=�6�   �� 5-      -   5        $��5 0 0 0q�5-       $	����61   $��Segoe MDL2 Assets)�6A   $��15��6`   $��18��6k   $��14(�6x   $|�False��6�   6�   �� 5.      $��5 0 0 0q�6u   ��6    �� $ CurrentTreino.Atleta.Nome�$ PropertyChanged=�6u   5/      50      �� 51      $ Vertical=�6   .+�52      �� $ 
Horizontal=�6   .+�53      �� $ Vertical=�6!   .+�54      �� $��Código exercicio:��6    $��0q�6<   $��0 5 0 0q�6H   �� 55      $ 
Horizontal=�6%   .+�56      �� -   5        $ tbCodigoExercicio��56   &   $	��130��6A   $ 60��6M   $��20��6\   $
��Left=�6h   ��6�   �� $ CurrentExercicio.Codigo�$ PropertyChanged=�6�   �� 57      -	   5        $��5 0 0 0q�57   (   $	����69   $��Segoe MDL2 Assets)�6I   $��15��6h   $��18��6s   $��14(�6�   $|�False��6�   6�   58      59      �� 5:      $ Vertical=�6!   $��5 0 0 0q�68   .+�5;      �� $��Descrição:��6    $��0q�65   $��0 5 0 0q�6A   �� 5<      $ 
Horizontal=�6%   .+�5=      �� $	��250��6'   $ 60��63   $��20��6B   $
��Left=�6N   $|�False��6i   ${�False��6{   ��6�   �� $  CurrentExercicio.Descricao�$ PropertyChanged=�5>      5?      �� 5@      $ Vertical=�6!   $��5 0 0 0q�68   .+�5A      �� $��Tipo:��6    $��0q�60   $��0 5 0 0q�6<   �� 5B      $ 
Horizontal=�6%   .+�5C      �� $	��100��6'   $ 60��63   $��20��6B   $
��Left=�6N   $|�False��6i   ${�False��6{   ��6�   �� $+ %CurrentExercicio.TipoTreino.Descricao�$ PropertyChanged=�5D      5E      �� 5F      $ Vertical=�6!   $��2 0 0 0q�68   .+�5G      �� $��Tempo (segundos):��6    $��0q�6<   $��0 5 0 0q�6H   ${�False��6Y   �� 5H      $ 
Horizontal=�6%   .+�5I      �� -
   5        $ tbTempoExercicio��5I   &   $	��110��6@   $ 60��6L   $
��Left=�6[   ��6v   �� $ CurrentExercicio.Tempo�$ PropertyChanged=�{�6�   �� $ CurrentExercicio.IsTempo�$ PropertyChanged=��� 5J      -   5        $��2 0 0 0q�5J   %   $	��100��66   $��20��6B   $��	Adicionar��6N   $��SemiBold"�6b   6x   5K      5L      5M      �� 5N      .+�5O      &   System.Windows.Controls.DataGrid  -   5          Name$ dgExercicios��5O   ,   $	��200��6   $��0 2 0 0q�6B   $   HorizontalScrollBarVisibility$
 Auto=�6S   	   AutoGenerateColumns$	 False��6x   
   AlternatingRowBackground

 �����   CanUserAddRows$ False��6�   ��6�   �� $ CurrentTreino.L_Exercicio�$ PropertyChanged=�   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6L      Header$ Código��6^      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Codigo+6n     5R      $
 True��6O   $ 	Descricao��6a   $	 250 6t    61   �� *	Descricao+6t     5S      $
 True��6Z   $ 	Descricao��6l   $	 100 6    61   �� *TipoTreino.Descricao+6     5T      $
 True��6K   $ Tempo��6]   $	 100 6l    61   �� *Tempo+6l   5V      5W      5X      �� 5Y      $
��Left=�6   .+�5Z      �� $�� ��6   $��0q�6$   �� 5[      $ 
Horizontal=�6   .+�5\      �� -   5        $	��130��5\      $��20��6)   $��Salvar��65   $��SemiBold"�6F   6\   5]      5^      �� 5_      $�� ��6   $��0q�6    �� 5`      �� 5a      $��Treinos existentes:��6   $��16(�62   $��SemiBold"�6@   $��0q�6V   �� 5b      $ 
Horizontal=�6   $��2q�62   .+�5c      �� $��Pesquisar: ��6   $��0q�6.   �� 5d      -   5        $ tbPesquisar��5d      $	��500��6/   $ 60��6;   $��20��6J   6V   5e      �� 5f      .+�5g        $��0 2 0 0q�6    5h        5i      $
 True��6H   $ Código��6Z      MinWidth$ 80Q�6j   $ * 6x    6-   �� *Codigo+6x     5j      $
 True��6K   $ Título��6]   $	 150Q�6m   $ * 6|    6-   �� *	Descricao+6|     5k      $
 True��6G   $
 Tipo��6Y   $	 100Q�6g   $ 80 6v    6-   �� *Tempo+6v     5l      $
 True��6G   $ 	Treinador��6Y   $	 250Q�6l   $ * 6{    6-   �� *Tempo+6{     5m      $
 True��6G   $ Atleta��6Y   $	 250Q�6i   $ * 6x    6-   �� *Tempo+6x     5n      $
 True��6G   $ Quantidade exercicios��6Y   $ 50Q�6x   $	 130 6�    6-   �� *Tempo+6�   5p      5q      5r      �� 5s   
   $��1��6   �� 5t   
   $��2��6   ��6&   �� $ 	TelaDados�$ PropertyChanged=�5u      5v      