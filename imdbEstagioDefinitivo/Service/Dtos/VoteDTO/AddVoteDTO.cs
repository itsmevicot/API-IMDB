﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.VoteDTO
{
    public class AddVoteDTO
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }

        [Required(ErrorMessage = "É necessário definir o valor de voto mínimo e máximo.")]
        [Range(0, 4)]
        public int VoteEvaluation { get; set; }
    }
}
