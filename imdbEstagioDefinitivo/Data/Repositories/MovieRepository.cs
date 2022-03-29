using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Dtos.MovieDTO;
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
        public MovieRepository(imdbContext context) : base(context)
        {
        
        }
        public async Task<IQueryable<Movie>> SearchMovieByDirector(string Diretor)
        {
            return _dbSet
                .IgnoreAutoIncludes()
                .Where(movie => movie.Director.Contains(Diretor))
                .Include(x => x.Actors.Where(x => x.Active))
                .Include(x => x.Genre.Where(x => x.Active));
        }

        public async Task<IQueryable<Movie>> SearchMovieByTitle(string Title)
        {
            return _dbSet
                .IgnoreAutoIncludes()
                .Where(movie => movie.Title.Contains(Title))
                .Include(x => x.Genre.Where(x => x.Active))
                .Include(x => x.Actors.Where(x => x.Active));
        }

        
        public async Task<IQueryable<Movie>> SearchMovieByGenre(string GenreName)
        {
            return _dbSet
                .IgnoreAutoIncludes()
                .Include(movie => movie.Genre).Where(movie => movie.Genre.Any(genre => genre.Name.Contains(GenreName)))
                .Include(x => x.Actors.Where(x => x.Active))
                .Include(x => x.Genre.Where(x => x.Active));
        }


        public async Task<IQueryable<Movie>> SearchMovieByActor(string ActorName)
        {
            return _dbSet
                .IgnoreAutoIncludes()
                .Include(movie => movie.Actors).Where(movie => movie.Actors.Any(actor => actor.Name.Contains(ActorName)))
                .Include(x => x.Actors.Where(x => x.Active))
                .Include(x => x.Genre.Where(x => x.Active));
        }

        public override Task<IQueryable<Movie>> GetAll()
        {
            return Task.FromResult(
                _dbSet.Where(x => x.Active)
                .IgnoreAutoIncludes()
                .Include(x => x.Actors.Where(x => x.Active))
                .Include(x => x.Genre.Where(x => x.Active))

                .AsQueryable());
        }
    }
}
