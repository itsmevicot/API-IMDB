using FluentResults;
using Service.Dtos.GenreDTO;

namespace Service.Services
{
    public interface IGenreService
    {
        Task<Result> DeleteGenre(int id);
        Task<Result<IEnumerable<ReadGenreDTO>>> GetAll();
        Task<Result<ReadGenreDTO>> GetById(int id);
        Task<Result> RegisterGenre(string genre);
        Task<Result> UpdateGenre(int id, string newName);
    }
}