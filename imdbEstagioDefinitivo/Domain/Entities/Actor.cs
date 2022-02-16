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
        public IEnumerable<Movie> Movies { get; set; }
    }
}
