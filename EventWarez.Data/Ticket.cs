using System.ComponentModel.DataAnnotations;

namespace EventWarez.Data
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int ShowId { get; set; }
        public virtual Show Show { get; set; }
        public int? AttId { get; set; }
        public virtual Attendee Attendee { get; set; }

        [Required]
        public int Price { get; set; }

        public enum TicketType { General, VIP }

        [Required]
        public TicketType TypeOfTicket { get; set; }
    }
}
