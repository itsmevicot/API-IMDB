using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.VoteDTO
{
    public class UpdateVoteDTO
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        [Required(ErrorMessage = "O voto tem valor mínimo 0 e máximo de 4.")]
        [Range(0, 4)]
        public int NewEvaluation { get; set; }
    }
}
