using System.Windows;
using CourseworkClient.ViewModels;

namespace CourseworkClient.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
