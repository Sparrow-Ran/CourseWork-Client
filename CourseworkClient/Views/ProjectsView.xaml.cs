using System.Windows;
using CourseworkClient.ViewModels;

namespace CourseworkClient.Views
{
    public partial class ProjectsView : Window
    {
        public ProjectsView()
        {
            InitializeComponent();
            DataContext = new ProjectsViewModel();
        }
    }
}
