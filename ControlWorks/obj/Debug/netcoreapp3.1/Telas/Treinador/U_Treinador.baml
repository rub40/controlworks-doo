   M S B A M L   `   `   `  ����  ControlWorks    ControlWorks.U_Treinador   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <controls'using:Microsoft.Toolkit.Uwp.UI.Controls     5      -   5        .��5	      � $��5q�6     � RowDefinitions  5
   
   �� 5      $��* �6    �� 5      $��10 �6    �� 5      $��* �6    .+�5   
   �� $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� .+�5      �� $��Código:��6   $��0q�6.   �� 5      -   5         ��Name$ tbCodigo��5      $��20��60   $	��130��6<   $
��Left=�6H   ��6�   ��  �� Path$ CurrentTreinador.Codigo� �� UpdateSourceTrigger$ PropertyChanged=�5      5      �� 5      .+�5      �� $
��CPF:��6   $��0q�6'   �� 5      -   5        $ tbCpf��5      $��20��6)   $	��130��65   $
��Left=�6A   ��6\   �� $ CurrentTreinador.Cpf�$ PropertyChanged=�5      �� 5      .+�5      �� $��Nome:��6   $��0q�6(   �� 5      -   5        $ tbNome��5      $��20��6*   $	��350��66    �� 	MaxLength$ 60��6B   $
��Left=�6Q   ��6l   �� $ CurrentTreinador.Nome�$ PropertyChanged=�5       �� 5!      .+�5"      �� $��	Endereco:��6   $��0q�6,   �� 5#      -   5        $ 
tbEndereco��5#      $��20��6.   $	��350��6:   $ 60��6F   $
��Left=�6U   ��6p   �� $ CurrentTreinador.Endereco�$ PropertyChanged=�5$      �� 5%      $
��Left=�6   .+�5&      �� $��	Telefone:��6   $��0q�6,   �� 5'      -   5        $ 
tbTelefone��5'      $��20��6.   $	��130��6:   $ 14��6F   ��6U   �� $ CurrentTreinador.Telefone�$ PropertyChanged=�5(      �� 5)      $
��Left=�6   .+�5*      �� $�� ��6   $��0q�6$   �� 5+      -   5        $	��130��5+      $��20��6%   $��Salvar��61   $��SemiBold"�6B   6X   5,      5-      �� 5.   
   $��1��6   �� 5/   
   $��2��6   ��6&   �� $ 	TelaDados�$ PropertyChanged=�50      51      