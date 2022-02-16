using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly DbSet<Movie> _dbSet;
        public MovieRepository(imdbContext context) : base(context)
        {
        
        }

        public async Task<Movie> GetMovieInformation(int id)
        {
            return await GetById(id);
        }

        public async Task<IEnumerable<Movie>> SearchMovieByDirector(string Diretor)
        {
            return await GetAll(movie => movie.Director == Diretor);
        }

        public async Task<IEnumerable<Movie>> SearchMovieByTitle(string Title)
        {
            return await GetAll(movie => movie.Title.Contains(Title));
        }

        
        public async Task<IEnumerable<Movie>> SearchMovieByGenre(string GenreName)
        {
            return _dbSet
                .Include(movie => movie.Genre).Where(movie => movie.Genre.Any(genre => genre.Name == GenreName));
        }

        public async Task<IEnumerable<Movie>> SearchMovieByActor(string ActorName)
        {
            return _dbSet
                .Include(movie => movie.Actors).Where(movie => movie.Actors.Any(actor => actor.Name == ActorName)); 
        }
        
    }
}
