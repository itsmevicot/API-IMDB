using Service.Dtos.ActorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.MovieDTO
{
    public class CreateMovieDTO 
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
    }
}
