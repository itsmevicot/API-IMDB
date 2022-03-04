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
        Task<Movie> GetById(int id);
        Task<IQueryable<Movie>> SearchMovieByDirector(string Diretor);
        Task<IQueryable<Movie>> SearchMovieByTitle(string Title);
        Task<IQueryable<Movie>> SearchMovieByGenre(string GenreName);
        Task<IQueryable<Movie>> SearchMovieByActor(string ActorName);
    }
}
