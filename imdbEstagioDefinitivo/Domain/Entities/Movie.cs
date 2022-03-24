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
        public int VoteCounter { get; set; } = 0;
        public int AverageVote { get; set; } = 0;
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Genre> Genre { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }


        public void RegisterVote(int evaluationVote)
        {
            VoteCounter++;
            AverageVote += evaluationVote; 
        }

        public void UpdateVote(int oldVote, int newVote)
        {
            AverageVote += (newVote - oldVote);
        }

        public decimal GetAverageVote()
        {
            if (VoteCounter == 0) 
            {
                return 0m; 
            }
            else 
            { 
                return AverageVote / (decimal)VoteCounter;
            }
        }
    }
}
