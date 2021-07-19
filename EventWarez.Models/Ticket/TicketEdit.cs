using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models.Ticket
{
    public class TicketEdit
    {
        [Required]
        public int TicketId { get; set; }
        [Required]
        public int AttId { get; set; }
    }
}
