using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController(IGenreService genreService) : ControllerBase
{
    private IGenreService service = genreService;
    
    [HttpGet]
    public async Task<ApiResponse<List<Genre>>> GetGenres()
    {
        return await service.GetGenresAsync();
    }

    [HttpGet("{id:int}")]
    public async Task GetGenre(int id)
    {
        await service.GetGenreAsync(id);
    }

    [HttpPost]
    public async Task AddGenre(Genre genre)
    {
        await service.AddGenreAsync(genre);
    }

    [HttpDelete]
    public async Task DeleteGenre(int id)
    {
        await service.DeleteGenreAsync(id);
    }

    [HttpPut]
    public async Task UpdateGenre(Genre genre)
    {
        await service.UpdateGenreAsync(genre);
    }

}
