   M S B A M L   `   `   `  ����  CourseworkClient.    (CourseworkClient.Views.CreateProjectView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Создать проект��5   	   $	��300��6    $	��400��6-   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   �� $��0��6   .+�5      �� $%��Название проекта��6   $
��Bold"�60   �� 5      ��6   �� *ProjectName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $!��Создать проект��6   $��0,10,0,0q�6W   ��6.   �� *CreateProjectCommand+6W   5      �� 5   
   
���  ��$��1��6C   $��0,10,0,0q�6P   ��6   �� *ErrorMessage+6P   5      5      