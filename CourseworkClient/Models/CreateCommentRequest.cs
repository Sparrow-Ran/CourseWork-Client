namespace CourseworkClient.Models
{
    public class CreateCommentRequest
    {
        public int IssueId { get; set; }
        public string Content { get; set; }
    }
}
