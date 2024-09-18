using System.Collections.Generic;
using System.Windows;
using System;

public static class NavigationService
{
    private static readonly Dictionary<string, Type> PagesByKey = new Dictionary<string, Type>();

    public static void Configure(string key, Type pageType)
    {
        if (PagesByKey.ContainsKey(key))
        {
            PagesByKey[key] = pageType;
        }
        else
        {
            PagesByKey.Add(key, pageType);
        }
    }

    public static void NavigateTo(string pageKey, object parameter = null)
    {
        if (PagesByKey.ContainsKey(pageKey))
        {
            var type = PagesByKey[pageKey];
            Window window;

            if (parameter != null)
            {
                window = (Window)Activator.CreateInstance(type, parameter);
            }
            else
            {
                window = (Window)Activator.CreateInstance(type);
            }

            window.Show();

            if (Application.Current.MainWindow != null && Application.Current.MainWindow != window)
            {
                Application.Current.MainWindow.Close();
            }

            Application.Current.MainWindow = window;
        }
        else
        {
            throw new ArgumentException($"Нет такой страницы: {pageKey}");
        }
    }
}
