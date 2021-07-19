using System;

namespace EventWarez.Models.Show
{
    public class ShowListItem
    {
        public int ShowId { get; set; }

        public string Feature { get; set; }

        public DateTime ShowTime { get; set; }

        public bool IsSoldOut { get; set; }
    }
}
