using System.Windows;
using System.Windows.Controls;

namespace CourseworkClient.Helpers
{
    public static class PasswordBoxAssistant
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAssistant), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject dp, string value)
        {
            dp.SetValue(BoundPasswordProperty, value);
        }

        private static bool _updating = false;

        public static void OnBoundPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (_updating)
                return;

            PasswordBox passwordBox = dp as PasswordBox;

            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

                if (!string.Equals(passwordBox.Password, e.NewValue as string))
                {
                    passwordBox.Password = e.NewValue as string;
                }

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        public static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _updating = true;

            PasswordBox passwordBox = sender as PasswordBox;
            SetBoundPassword(passwordBox, passwordBox.Password);

            _updating = false;
        }
    }
}
