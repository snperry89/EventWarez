using EventWarez.Data;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models
{
    public class WorkOrderCreate
    {
        public int? StaffId { get; set; }

        [Required]
        public int ShowId { get; set; }

        public Department Department { get; set; }
    }
}
