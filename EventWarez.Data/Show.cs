using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Data
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        public string Feature { get; set; }

        [Required]
        public DateTime ShowTime { get; set; }

        public virtual List<WorkOrder> WorkOrders { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public bool IsSoldOut { get; set; }
    }
}
