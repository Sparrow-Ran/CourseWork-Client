using System.Windows;
using CourseworkClient.Services;
using CourseworkClient.Views;

namespace CourseworkClient
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Настройка навигации
            NavigationService.Configure("Login", typeof(LoginView));
            NavigationService.Configure("Projects", typeof(ProjectsView));
            NavigationService.Configure("CreateProject", typeof(CreateProjectView));
            NavigationService.Configure("CreateIssue", typeof(CreateIssueView));
            NavigationService.Configure("Issue", typeof(IssueView));

            // Запуск приложения с окна входа
            NavigationService.NavigateTo("Login");
        }
    }
}
