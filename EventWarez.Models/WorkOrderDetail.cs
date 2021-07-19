using EventWarez.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models
{
    public class WorkOrderDetail
    {
        public int WorkOrderId { get; set; }
        public int? StaffId { get; set; }
        public int ShowId { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
