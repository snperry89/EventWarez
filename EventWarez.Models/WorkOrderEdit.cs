using EventWarez.Data;

namespace EventWarez.Models
{
    public class WorkOrderEdit
    {
        public int WorkOrderId { get; set; }
        public int? StaffId { get; set; }
        public int ShowId { get; set; }
        public Department Department { get; set; }
    }
}
