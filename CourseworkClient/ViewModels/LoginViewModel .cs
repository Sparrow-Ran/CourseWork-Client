using System;
using System.Windows.Input;
using CourseworkClient.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CourseworkClient.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;

        public LoginViewModel()
        {
            _apiService = new ApiService();
            LoginCommand = new RelayCommand(Login);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        // Свойство для отображения сообщений об ошибках
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        private async void Login()
        {
            try
            {
                var token = await _apiService.AuthenticateAsync(Username, Password);
                Properties.Settings.Default.JwtToken = token;
                Properties.Settings.Default.Save();

                // Обновление заголовка Authorization
                ApiService.Instance.UpdateAuthorizationHeader();
                NavigationService.NavigateTo("Projects");
                ErrorMessage = string.Empty; // Очистить сообщение об ошибке
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при входе: " + ex.Message;
            }
        }
    }
}
