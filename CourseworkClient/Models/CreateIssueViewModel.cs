using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CourseworkClient.Models;
using CourseworkClient.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CourseworkClient.ViewModels
{
    public class CreateIssueViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;
        private readonly int _projectId;

        public CreateIssueViewModel(int projectId)
        {
            _apiService = new ApiService();
            _projectId = projectId;
            CreateIssueCommand = new RelayCommand(CreateIssue);
            LoadStatusesAndPriorities();
        }

        // Свойства для создания задачи
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatusDTO SelectedStatus { get; set; }
        public IssuePriorityDTO SelectedPriority { get; set; }

        // Списки статусов и приоритетов
        public ObservableCollection<IssueStatusDTO> Statuses { get; private set; } = new ObservableCollection<IssueStatusDTO>();
        public ObservableCollection<IssuePriorityDTO> Priorities { get; private set; } = new ObservableCollection<IssuePriorityDTO>();

        // Команда создания задачи
        public RelayCommand CreateIssueCommand { get; }

        private async void LoadStatusesAndPriorities()
        {
            var statuses = await _apiService.GetIssueStatusesAsync();
            foreach (var status in statuses)
            {
                Statuses.Add(status);
            }

            var priorities = await _apiService.GetIssuePrioritiesAsync();
            foreach (var priority in priorities)
            {
                Priorities.Add(priority);
            }
        }

        private async void CreateIssue()
        {
            var issueRequest = new CreateIssueRequest
            {
                ProjectId = _projectId,
                Title = this.Title,
                Description = this.Description,
                StatusId = SelectedStatus?.Id,
                PriorityId = SelectedPriority?.Id
            };

            var issue = await _apiService.CreateIssueAsync(issueRequest);

            // После создания задачи можно вернуться к списку задач или открыть созданную задачу
            NavigationService.NavigateTo("Issue", issue.Id);
        }
    }
}
