using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<Movie> GetMovieInformation(int id);
        Task<IEnumerable<Movie>> SearchMovieByDirector(string Diretor);
        Task<IEnumerable<Movie>> SearchMovieByTitle(string Title);
        Task<IEnumerable<Movie>> SearchMovieByGenre(string GenreName);
    }
}
