   M S B A M L   `   `   `  ����K  GCourseworkClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:CourseworkClient.HelpersCourseworkClient.Helpers  5   	   &     CourseworkClient.Views.LoginView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :helpers&clr-namespace:CourseworkClient.Helpers     5   	     � Title$  Вход��5   	   $	��300��6   $	��400��6#   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,0,0,10q�6"   .+�5      �� $%��Имя пользователя��6   �� 5      ��6   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $��Пароль��6   G� 5      3   -CourseworkClient.Helpers.PasswordBoxAssistant   BoundPassword 6   �� *
Password+ �� Mode$ TwoWay=�5      �� 5   
   $��
Войти��6   $��2��6B   ��6!   �� *LoginCommand+6B   �� 5   
   
���  ��$��3��6C   $��0,10,0,0q�6P   ��6   �� *ErrorMessage+6P   5      5      