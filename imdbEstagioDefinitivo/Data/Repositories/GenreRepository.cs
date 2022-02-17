using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly DbSet<Genre> _dbSet;
        public GenreRepository(imdbContext context) : base(context)
        {
          
        }

        public async Task<IQueryable<Genre>> SearchMovieByGenre(string GenreName)
        {
            return _dbSet
                .Where(genre => genre.Name.Contains(GenreName))
                .Include(genre => genre.Movies.Where(movie => movie.Active));

        }
    }
}
