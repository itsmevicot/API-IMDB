using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public int VoteCounter { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual IEnumerable<Actor> Actors { get; set; }
        public virtual IEnumerable<Genre> Genre { get; set; }
        public virtual IEnumerable<Vote> Votes { get; set; }
    }
}
