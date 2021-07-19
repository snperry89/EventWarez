using EventWarez.Models.Ticket;
using System.Collections.Generic;

namespace EventWarez.Models.Attendee
{
    public class AttendeeDetail
    {
        public int AttId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TicketListItem> Tickets { get; set; }
    }
}
