using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Data
{
    public class Attendee
    {
        [Key]
        public int AttId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

        
    }
}
