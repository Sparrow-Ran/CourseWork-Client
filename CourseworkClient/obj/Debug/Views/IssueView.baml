   M S B A M L   `   `   `  ����K  GCourseworkClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseworkClient.ViewModelsCourseworkClient.ViewModels  5   	   &     CourseworkClient.Views.IssueView   5   	   0vm)clr-namespace:CourseworkClient.ViewModels  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Задача��5   	   $	��700��6   $	��800��6%   $	��400��5   	   $	��600��6    � 
ResizeMode$ NoResize=�6(   .��5      � $��10q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   $��2��62   $��0,0,0,10q�6F   .+�5      �� $#��Название задачи��6   $
��Bold"�6/   �� 5      ��6   �� *Issue.Title+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��Приоритет��6   $
��Bold"�6)   �� 5      ��6   �� *Issue.Priority.Name+$ PropertyChanged=��� 5      $��Статус��6   $
��Bold"�6&   �� 5      ��6   �� *Issue.Status.Name+$ PropertyChanged=��� 5      $��Описание��6   $��0,10,0,0q�6(   $
��Bold"�6:   �� 5       �� AcceptsReturn . $	��100��6s    �� TextWrapping$
 Wrap=�6�   ��6   �� *Issue.Description+$ PropertyChanged=�6�   5      A� 5!   
   $��1��6   $��0��6#    A� Columns$ 2��63   $
��Left=�6?   $��0,10,0,0q�6Z   .+�5"      �� $#��Обновить задачу��6   $	��150��6V   $��5q�6b   ��6/   �� *UpdateIssueCommand+6b   �� 5#      $!��Удалить задачу��6   $	��150��6U   $��5q�6a   ��6.   �� *DeleteIssueCommand+6a   5$      �� 5'   
   $��1��6   $��1��6   $$��Назад на главную��6.   $��Right=�6q   $��0,10,0,0q�6�   $	��150��6�   ��6I   �� *GoToMainViewCommand+6�   �� 5*   
   $��2��6   $��0��6"   $��2��62   $��	0,10,0,10q�6F   .+�5+      �� $��Комментарии��6   $
��Bold"�6+   $��16(�6=   �� 5,      $	��200��68   ��6   �� *
Comments+��5-      �� 5.      .R�5/      �� $��5q�6%   .+�50      �� $
��Bold"�6I   ��6(   �� *Author.Username+6I   �� 51      $
��Wrap=�6A   ��6(   �� *	Content+6A   �� 52      $��Italic$�6C   $��10(�6V   ��6(   �� *	CreatedAt+6V   �� 53      $��Удалить��6%   $��0,5,0,0q�54   B   ��53   7   �� *" DataContext.DeleteCommentCommand+ �� RelativeSource �� 	 �� AncestorType$	 WindowL���54   %   �� 6B   55      56      58      �� 59      $/��)Загрузить комментарии��6   $��0,5,0,0q�6]   $
��Left=�6n   ��65   �� *LoadCommentsCommand+6n   5:      �� 5=   
   $��3��6   $��0��6"   $��2��62   .+�5>      �� $-��'Добавить комментарий��6   $
��Bold"�64   �� 5?       . $��60��6s   $
 Wrap=�6   ��6   �� *NewCommentContent+$ PropertyChanged=�6   �� 5@      $��Добавить��6   $��0,5,0,0q�6Q   ��6(   �� *CreateCommentCommand+6Q   5A      �� 5D   
   $��3��6   $��0��6!   $��2��61   
���  ��$��Bottom=�6t   $��0,10,0,0q�6�   ��6E   �� *ErrorMessage+6�   5E      5F      