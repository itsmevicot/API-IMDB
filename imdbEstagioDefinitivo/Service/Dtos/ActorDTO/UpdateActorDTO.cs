using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.ActorDTO
{
    public class UpdateActorDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.");
        public string Name { get; set; }    
    }
}
