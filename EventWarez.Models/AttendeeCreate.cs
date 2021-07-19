using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models.Attendee
{
    public class AttendeeCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "First Name must be more than 2 characters.")]
        [MaxLength(12, ErrorMessage = "First Name must be less than 12 characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Last Name must be more than 2 characters.")]
        [MaxLength(12, ErrorMessage = "Last Name must be less than 12 characters")]
        public string LastName { get; set; }
    }
}
