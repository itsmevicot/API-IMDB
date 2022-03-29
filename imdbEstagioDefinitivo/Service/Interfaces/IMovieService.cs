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
        Task<Result<ReadMovieDto>> GetById(int id);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByActor(string actor, int offset = 0, int limit = 0);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByDirector(string director, int offset = 0, int limit = 0);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByGenre(string genre, int offset = 0, int limit = 0);
        Task<Result<IEnumerable<ReadMovieDto>>> SearchMovieByTitle(string title, int offset = 0, int limit = 0);
        Task<Result> RegisterMovie(CreateMovieDTO cadastrarFilme);
        Task<Result> DeleteMovie(int id);
        Task<Result<IEnumerable<ReadMovieDto>>> GetAllMovies(int offset = 0, int limit = 0);
    }
}
