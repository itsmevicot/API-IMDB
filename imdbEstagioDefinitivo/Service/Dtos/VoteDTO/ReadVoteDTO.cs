using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.VoteDTO
{
    public class ReadVoteDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }

        [Required(ErrorMessage = "É necessário definir o valor de voto mínimo e máximo.")]
        [Range(0, 4)]
        public int Evaluation { get; set; }
    }
}
