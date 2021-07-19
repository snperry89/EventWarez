using System;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Data
{
    public enum Department { BoxOffice, Bar, Security, Floor }
    public class WorkOrder
    {
        [Key]
        public int WorkOrderId { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        [Required]
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }

        [Required]
        public Department Department { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
