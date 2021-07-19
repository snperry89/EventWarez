using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models.Ticket
{
    public class TicketDetail
    {
        [Required]
        public int TicketId { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage = "Feature Title must be 32 Chars or less.")]
        public string Feature { get; set; }
        public int? AttId { get; set; }
    }
}
