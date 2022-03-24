using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Actor : Entity<int>
    { 
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
