using FluentResults;
using Service.Dtos.MovieDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMovieService
    {
        Task<ReadMovieDto> GetById(int id);
        Task<Result<ReadMovieDto>> SearchMovieByActor(string actor);
        Task<Result<ReadMovieDto>> SearchMovieByDirector(string director);
        Task<Result<ReadMovieDto>> SearchMovieByGenre(string genre);
        Task<Result<ReadMovieDto>> SearchMovieByTitle(string title);
        Task<Result> RegisterMovie(CreateMovieDTO cadastrarFilme);
    }
}
