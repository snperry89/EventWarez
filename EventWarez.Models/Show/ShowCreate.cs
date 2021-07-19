using System;
using System.ComponentModel.DataAnnotations;

namespace EventWarez.Models.Show
{
    public class ShowCreate
    {
        [Required]
        public string Feature { get; set; }

        [Required]
        public DateTime ShowTime { get; set; }
    }
}
