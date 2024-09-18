using System;
using System.Windows.Input;
using CourseworkClient.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CourseworkClient.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace CourseworkClient.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;

        public CreateProjectViewModel()
        {
            _apiService = new ApiService();
            CreateProjectCommand = new RelayCommand(CreateProject);
        }

        private string _projectName;
        public string ProjectName
        {
            get => _projectName;
            set => Set(ref _projectName, value);
        }

        // Свойство для отображения сообщений об ошибках
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        public ICommand CreateProjectCommand { get; }

        private async void CreateProject()
        {
            if (string.IsNullOrWhiteSpace(ProjectName))
            {
                ErrorMessage = "Название проекта не может быть пустым.";
                return;
            }

            var request = new CreateProjectRequest
            {
                Name = ProjectName // Убедитесь, что ProjectName не пустой
            };

            var jsonData = JsonConvert.SerializeObject(request);
            Console.WriteLine("Request JSON: " + jsonData);


            try
            {
                var project = await _apiService.CreateProjectAsync(request);
                // После успешного создания проекта можно закрыть окно и обновить список проектов
                NavigationService.NavigateTo("Projects");
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (HttpRequestException httpEx)
            {
                // Обработка специфических HTTP-ошибок
                ErrorMessage = $"Ошибка при создании проекта: {httpEx.Message} + {jsonData}";
            }
            catch (Exception ex)
            {
                // Общая обработка ошибок
                ErrorMessage = $"Произошла непредвиденная ошибка: {ex.Message}";
            }
        }
    }
}
