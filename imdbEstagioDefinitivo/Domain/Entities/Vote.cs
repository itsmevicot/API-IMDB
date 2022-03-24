using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vote : Entity<int>
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int VoteEvaluation { get; set; }
        public virtual User User { get; set;} 
        public virtual Movie Movie { get; set; }
    }
}
