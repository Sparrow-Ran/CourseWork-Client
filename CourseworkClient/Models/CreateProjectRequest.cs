using System.ComponentModel.DataAnnotations;

namespace CourseworkClient.Models
{
    public class CreateProjectRequest
    {
        [Required]
        public string Name { get; set; }
    }

}
