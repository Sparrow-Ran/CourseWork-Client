using System.Windows;
using CourseworkClient.ViewModels;

namespace CourseworkClient.Views
{
    public partial class CreateIssueView : Window
    {
        public CreateIssueView(int projectId)
        {
            InitializeComponent();
            DataContext = new CreateIssueViewModel(projectId);
        }
    }
}
