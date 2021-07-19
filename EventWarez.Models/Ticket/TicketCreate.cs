using System.ComponentModel.DataAnnotations;
using static EventWarez.Data.Ticket;

namespace EventWarez.Models.Ticket
{
    public class TicketCreate
    {
        [Required]
        public int Price { get; set; }
        [Required]
        public TicketType TypeOfTicket { get; set; }
        [Required]
        public int ShowId { get; set; }
    }
}
