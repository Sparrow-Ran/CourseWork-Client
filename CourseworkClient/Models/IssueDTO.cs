using CourseworkClient.Models;

public class IssueDTO
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public IssueStatusDTO? Status { get; set; }
    public IssuePriorityDTO? Priority { get; set; }
    public UserDTO? Assignee { get; set; }
}
