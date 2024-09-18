using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CourseworkClient.Models;
using CourseworkClient.Services;

namespace CourseworkClient.ViewModels
{
    public class ProjectsViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;

        public ProjectsViewModel()
        {
            _apiService = new ApiService();
            Projects = new ObservableCollection<ProjectDTO>();
            Issues = new ObservableCollection<IssueDTO>();

            LoadProjectsCommand = new RelayCommand(LoadProjects);
            LoadIssuesCommand = new RelayCommand(LoadIssues, CanLoadIssues);
            CreateIssueCommand = new RelayCommand(CreateIssue, CanCreateIssue);
            OpenIssueCommand = new RelayCommand(OpenIssue, CanOpenIssue);
            CreateProjectCommand = new RelayCommand(CreateProject);

            // Загрузить проекты при инициализации
            LoadProjects();
        }

        // Свойства

        public ObservableCollection<ProjectDTO> Projects { get; set; }

        private ProjectDTO _selectedProject;
        public ProjectDTO SelectedProject
        {
            get => _selectedProject;
            set
            {
                Set(ref _selectedProject, value);
                LoadIssuesCommand.RaiseCanExecuteChanged();
                CreateIssueCommand.RaiseCanExecuteChanged();
                // Очищаем список задач при смене проекта
                Issues.Clear();
            }
        }

        public ObservableCollection<IssueDTO> Issues { get; set; }

        private IssueDTO _selectedIssue;
        public IssueDTO SelectedIssue
        {
            get => _selectedIssue;
            set
            {
                Set(ref _selectedIssue, value);
                OpenIssueCommand.RaiseCanExecuteChanged();
            }
        }

        // Свойство для отображения сообщений об ошибках
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        // Команды

        public RelayCommand LoadProjectsCommand { get; }
        public RelayCommand LoadIssuesCommand { get; }
        public RelayCommand CreateIssueCommand { get; }
        public RelayCommand OpenIssueCommand { get; }
        public RelayCommand CreateProjectCommand { get; }

        // Методы команд

        private async void LoadProjects()
        {
            try
            {
                var projects = await _apiService.GetUserProjectsAsync();
                Projects.Clear();
                foreach (var project in projects)
                {
                    Projects.Add(project);
                }
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при загрузке проектов: " + ex.Message;
            }
        }

        private bool CanLoadIssues()
        {
            return SelectedProject != null;
        }

        private async void LoadIssues()
        {
            if (SelectedProject == null)
                return;

            try
            {
                var issues = await _apiService.GetIssuesByProjectAsync(SelectedProject.Id);
                Issues.Clear();
                foreach (var issue in issues)
                {
                    Issues.Add(issue);
                }
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при загрузке задач: " + ex.Message + $"{SelectedProject.Id}, {SelectedProject.Name}" ;
            }
        }

        private bool CanCreateIssue()
        {
            return SelectedProject != null;
        }

        private void CreateIssue()
        {
            try
            {
                // Переход к окну создания задачи с передачей идентификатора проекта
                NavigationService.NavigateTo("CreateIssue", SelectedProject.Id);
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при открытии окна создания задачи: " + ex.Message;
            }
        }

        private bool CanOpenIssue()
        {
            return SelectedIssue != null;
        }

        private void OpenIssue()
        {
            try
            {
                // Переход к окну задачи
                NavigationService.NavigateTo("Issue", SelectedIssue.Id);
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при открытии задачи: " + ex.Message;
            }
        }

        private void CreateProject()
        {
            try
            {
                // Переход к окну создания проекта
                NavigationService.NavigateTo("CreateProject");
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при открытии окна создания проекта: " + ex.Message;
            }
        }
    }
}
