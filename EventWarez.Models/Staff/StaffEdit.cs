using EventWarez.Data;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models.Staff
{
    public class StaffEdit
    {
        public int StaffId { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string FirstName { get; set; }
       
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string LastName { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
