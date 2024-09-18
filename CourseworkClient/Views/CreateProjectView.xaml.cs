using System.Windows;
using CourseworkClient.ViewModels;

namespace CourseworkClient.Views
{
    public partial class CreateProjectView : Window
    {
        public CreateProjectView()
        {
            InitializeComponent();
            DataContext = new CreateProjectViewModel();
        }
    }
}
