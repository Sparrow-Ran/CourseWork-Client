   M S B A M L   `   `   `  ����  CourseworkClient,    &CourseworkClient.Views.CreateIssueView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Создание задачи��5   	   $	��400��6!   $	��600��6.   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5
   
   �� .+�5      �� $#��Название задачи��6   $
��Bold"�6/   �� 5      ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��Описание��6   $��0,10,0,0q�6(   $
��Bold"�6:   �� 5       �� AcceptsReturn . $	��100��6m    �� TextWrapping$
 Wrap=�6z   ��6   �� *Description+$ PropertyChanged=�6z   �� 5      $��Статус��6   $��0,10,0,0q�6&   $
��Bold"�68   �� 5       �� DisplayMemberPath$
 Name��68   ��6   �� *
Statuses+ �� SelectedItem 6Q   �� *SelectedStatus+�� 5      $��Приоритет��6   $��0,10,0,0q�6)   $
��Bold"�6;   �� 5      $
 Name��6:   ��6   �� *
Priorities+ 6S   �� *SelectedPriority+�� 5      $!��Создать задачу��6   $��0,10,0,0q�6U   ��6.   �� *CreateIssueCommand+6U   5      5      5      