   M S B A M L   `   `   `  ���� K  GCourseworkClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CourseworkClient.ViewModelsCourseworkClient.ViewModels  &     CourseworkClient.Views.IssueView   0vm)clr-namespace:CourseworkClient.ViewModels  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Задача��$	��600��$	��800��.��� $��10q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��0,0,0,10q�.+��� $#��Название задачи��$
��Bold"��� ���� *Issue.Title+ �� UpdateSourceTrigger$ PropertyChanged=��� $��Описание��$��0,10,0,0q�$
��Bold"���  �� AcceptsReturn . $	��100�� �� TextWrapping$
 Wrap=����� *Issue.Description+$ PropertyChanged=��� $#��Обновить задачу��$��0,10,0,0q����� *UpdateIssueCommand+�� $!��Удалить задачу��$��0,5,0,0q����� *DeleteIssueCommand+�� $��1��$��	0,10,0,10q�.+��� $��Комментарии��$
��Bold"�$��16(��� ���� *
Comments+���� .R��� $��5q�.+��� $
��Bold"����� *Author.Username+�� $
��Wrap=����� *	Content+�� $��Italic$�$��10(����� *	CreatedAt+�� $/��)Загрузить комментарии��$��0,5,0,0q����� *LoadCommentsCommand+�� $��2��.+��� $-��'Добавить комментарий��$
��Bold"���  . $��60��$
 Wrap=����� *NewCommentContent+$ PropertyChanged=��� $��Добавить��$��0,5,0,0q����� *CreateCommentCommand+