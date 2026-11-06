using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    private readonly IAuthorRepository repository = authorRepository;

    public async Task<ApiResponse<bool>> AddAuthorAsync(Author author)
    {
        var res = await repository.AddAuthorAsync(author);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteAuthorAsync(int id)
    {
        var res = await repository.DeleteAuthorAsync(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<Author>> GetAuthorAsync(int id)
    {
        var res = await repository.GetAuthorAsync(id);
        return new ApiResponse<Author>(HttpStatusCode.OK, "Author with given id.", res);
    }

    public async Task<ApiResponse<List<Author>>> GetAuthorsAsync()
    {
        var res = await repository.GetAuthorsAsync();
        return new ApiResponse<List<Author>>(HttpStatusCode.OK, "List of authors.", res);
    }

    public async Task<ApiResponse<bool>> UpdateAuthorAsync(Author author)
    {
        var res = await repository.UpdateAuthorAsync(author);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<int>> GetAuthorsAmountAsync()
    {
        var res = await repository.GetAuthorsAmountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Authors amount:", res);
    }
}
