using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CourseworkClient.Models;
using CourseworkClient.Services;

namespace CourseworkClient.ViewModels
{
    public class IssueViewModel : ViewModelBase
    {
        private readonly ApiService _apiService;
        private int _issueId;

        public IssueViewModel(int issueId)
        {
            _apiService = new ApiService();
            _issueId = issueId;

            LoadIssue();
            LoadCommentsCommand = new RelayCommand(LoadComments);
            UpdateIssueCommand = new RelayCommand(UpdateIssue);
            DeleteIssueCommand = new RelayCommand(DeleteIssue);
            CreateCommentCommand = new RelayCommand(CreateComment);
            DeleteCommentCommand = new RelayCommand<CommentDTO>(DeleteComment);
            // Команда для возврата на главную
            GoToMainViewCommand = new RelayCommand(GoToMainView);
        }

        // Команда для возврата на главное окно
        public RelayCommand GoToMainViewCommand { get; }

        private void GoToMainView()
        {
            NavigationService.NavigateTo("Projects");
        }

        private IssueDTO _issue;
        public IssueDTO Issue
        {
            get => _issue;
            set => Set(ref _issue, value);
        }

        private ObservableCollection<CommentDTO> _comments;
        public ObservableCollection<CommentDTO> Comments
        {
            get => _comments ?? (_comments = new ObservableCollection<CommentDTO>());
            set => Set(ref _comments, value);
        }

        private string _newCommentContent;
        public string NewCommentContent
        {
            get => _newCommentContent;
            set => Set(ref _newCommentContent, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => Set(ref _errorMessage, value);
        }

        public RelayCommand LoadCommentsCommand { get; }
        public RelayCommand UpdateIssueCommand { get; }
        public RelayCommand DeleteIssueCommand { get; }
        public RelayCommand CreateCommentCommand { get; }
        public RelayCommand<CommentDTO> DeleteCommentCommand { get; }

        private async void LoadIssue()
        {
            try
            {
                Issue = await _apiService.GetIssueByIdAsync(_issueId);
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при загрузке задачи: " + ex.Message;
            }
        }

        private async void LoadComments()
        {
            try
            {
                var comments = await _apiService.GetCommentsByIssueAsync(_issueId);
                Comments = new ObservableCollection<CommentDTO>(comments);
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при загрузке комментариев: " + ex.Message;
            }
        }

        private async void UpdateIssue()
        {
            try
            {
                var updateRequest = new UpdateIssueRequest
                {
                    Title = Issue.Title,
                    Description = Issue.Description,
                    StatusId = Issue.Status?.Id,
                    PriorityId = Issue.Priority?.Id,
                    AssignedTo = Issue.Assignee?.Id
                };

                await _apiService.UpdateIssueAsync(_issueId, updateRequest);
                LoadIssue();
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при обновлении задачи: " + ex.Message;
            }
        }

        private async void DeleteIssue()
        {
            try
            {
                await _apiService.DeleteIssueAsync(_issueId);
                NavigationService.NavigateTo("Projects");
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при удалении задачи: " + ex.Message;
            }
        }

        private async void CreateComment()
        {
            try
            {
                var commentRequest = new CreateCommentRequest
                {
                    IssueId = _issueId,
                    Content = NewCommentContent
                };

                var comment = await _apiService.CreateCommentAsync(commentRequest);
                Comments.Add(comment);
                NewCommentContent = string.Empty;
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при добавлении комментария: " + ex.Message;
            }
        }

        private async void DeleteComment(CommentDTO comment)
        {
            try
            {
                await _apiService.DeleteCommentAsync(comment.Id);
                Comments.Remove(comment);
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = "Ошибка при удалении комментария: " + ex.Message;
            }
        }
    }
}
