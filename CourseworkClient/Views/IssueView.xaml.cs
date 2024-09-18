using System.Windows;
using CourseworkClient.ViewModels;

namespace CourseworkClient.Views
{
    public partial class IssueView : Window
    {
        public IssueView(int issueId)
        {
            InitializeComponent();
            DataContext = new IssueViewModel(issueId);
        }
    }
}
