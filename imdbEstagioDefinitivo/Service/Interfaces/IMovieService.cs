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
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByActor(string actor);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByDirector(string director);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByGenre(string genre);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByTitle(string title);
        Task<Result> RegisterMovie(CreateMovieDTO cadastrarFilme);
        Task<Result> InactivateMovie(int id);
    }
}
