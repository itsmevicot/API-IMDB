using Data.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using Service.Services.Authentication;
using Service.Services.Utils;

namespace imdbAPI.Extensions
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddDependenceInjection(this IServiceCollection services) 
        {
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository , UserRepository>();
            services.AddScoped<IVoteRepository , VoteRepository>();
            services.AddScoped<IAdminAuthService, AdminAuthService>();
            services.AddScoped<IHasherService, HasherService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
