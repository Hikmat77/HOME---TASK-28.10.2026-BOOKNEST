using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGenreService
{
    Task AddGenreAsync(Genre genre);
    Task UpdateGenreAsync(Genre genre);
    Task DeleteGenreAsync(int id);
    Task GetGenreAsync(int id);
    Task GetAllGenresAsync();
    Task GetGenresAmountAsync();
    Task<ApiResponse<List<Genre>>> GetGenresAsync();

}
