using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos.GenreDTO
{
    public class UpdateGenreDTO
    {
        [Required(ErrorMessage = "O nome do gênero é obrigatório.")]
        public string Name { get; set; }
    }
}
