﻿using Domain.Entities;
using Service.Dtos.ActorDTO;
using Service.Dtos.GenreDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.MovieDTO
{ 
    public class ReadMovieDto
    {
        public int Id { get; set; } 
        public string Title { get; set; }  
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public decimal AverageVote { get; set; }
        public int VoteCounter { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ReadActorDTO> Actors { get; set; } 
        public List<ReadGenreDTO> Genre{ get; set; }
    }
}
