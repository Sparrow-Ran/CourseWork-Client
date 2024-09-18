using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CourseworkClient.Models;

namespace CourseworkClient.Services
{
    public class ApiService
    {
        private static ApiService _instance;
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7202/")
            };
            UpdateAuthorizationHeader();
        }

        public static ApiService Instance => _instance = new ApiService();

        public void UpdateAuthorizationHeader()
        {
            var token = Properties.Settings.Default.JwtToken;
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var loginModel = new
            {
                Username = username,
                Password = password
            };

            var content = new StringContent(JsonConvert.SerializeObject(loginModel), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);
                return loginResponse.Token;
            }
            else
            {
                throw new Exception("Ошибка аутентификации.");
            }
        }

        // Метод для получения проектов пользователя
        public async Task<List<ProjectDTO>> GetUserProjectsAsync()
        {
            var response = await _httpClient.GetAsync("api/Projects/GetUserProjects");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var projects = JsonConvert.DeserializeObject<List<ProjectDTO>>(responseString);
            return projects;
        }

        // Методы для создания, обновления и удаления проектов
        public async Task<ProjectDTO> CreateProjectAsync(CreateProjectRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Projects/Create", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<ProjectDTO>(responseString);
            return project;
        }

        public async Task<IssueDTO> GetIssueByIdAsync(int issueId)
        {
            var response = await _httpClient.GetAsync($"api/Issues/GetById/{issueId}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var issue = JsonConvert.DeserializeObject<IssueDTO>(responseString);
            return issue;
        }

        public async Task UpdateIssueAsync(int issueId, UpdateIssueRequest issue)
        {
            var content = new StringContent(JsonConvert.SerializeObject(issue), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/Issues/Update/{issueId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteIssueAsync(int issueId)
        {
            var response = await _httpClient.DeleteAsync($"api/Issues/Delete/{issueId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<CommentDTO> CreateCommentAsync(CreateCommentRequest comment)
        {
            var content = new StringContent(JsonConvert.SerializeObject(comment), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Comments/Create", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var commentDTO = JsonConvert.DeserializeObject<CommentDTO>(responseString);
            return commentDTO;
        }

        public async Task<List<CommentDTO>> GetCommentsByIssueAsync(int issueId)
        {
            var response = await _httpClient.GetAsync($"api/Comments/GetByIssue/GetByIssue/{issueId}");
            response.EnsureSuccessStatusCode(); // Эта строка вызывает исключение, если ответ не успешный (404, 500 и т.д.)

            var responseString = await response.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<CommentDTO>>(responseString);
            return comments;
        }


        public async Task<List<IssueStatusDTO>> GetIssueStatusesAsync()
        {
            var response = await _httpClient.GetAsync("api/IssueStatuses/GetAll");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var statuses = JsonConvert.DeserializeObject<List<IssueStatusDTO>>(responseString);
            return statuses;
        }

        public async Task<List<IssuePriorityDTO>> GetIssuePrioritiesAsync()
        {
            var response = await _httpClient.GetAsync("api/IssuePriorities/GetAll");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var priorities = JsonConvert.DeserializeObject<List<IssuePriorityDTO>>(responseString);
            return priorities;
        }

        public async Task<IssueDTO> CreateIssueAsync(CreateIssueRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Issues/Create", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var issueDTO = JsonConvert.DeserializeObject<IssueDTO>(responseString);
            return issueDTO;
        }

        public async Task<List<IssueDTO>> GetIssuesByProjectAsync(int projectId)
        {
            var response = await _httpClient.GetAsync($"api/Issues/GetIssuesByProject/Project/{projectId}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var issues = JsonConvert.DeserializeObject<List<IssueDTO>>(responseString);
            return issues;
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var response = await _httpClient.DeleteAsync($"api/Comments/Delete/{commentId}");
            response.EnsureSuccessStatusCode();
        }


    }
}
