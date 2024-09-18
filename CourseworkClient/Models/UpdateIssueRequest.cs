namespace CourseworkClient.Models
{
    public class UpdateIssueRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StatusId { get; set; }
        public int? PriorityId { get; set; }
        public int? AssignedTo { get; set; }
    }
}
