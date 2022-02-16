using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO_s.MovieDTO
{
    public class ReadMovieDto
    {
        public string Title { get; set; }  
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public int Rating { get; set; }
        public int VoteCounter { get; set; }
        public List<Actor> Actors { get; set; } 
        public List<Genre> Genres { get; set; }

    }
}
