using System;
using System.ComponentModel.DataAnnotations;
using static EventWarez.Data.Ticket;

namespace EventWarez.Models.Ticket
{
    public class TicketListItem
    {
        public int TicketId { get; set; }
        public int Price { get; set; }
        public TicketType TypeTicket { get; set; }
        [Display(Name = "Headline")]
        public string Feature { get; set; }
        [Display(Name = "Show Time")]
        public DateTime ShowTime { get; set; }
    }
}
