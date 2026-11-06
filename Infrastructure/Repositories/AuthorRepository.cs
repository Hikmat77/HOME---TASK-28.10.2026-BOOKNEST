using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext appDbContext) : IAuthorRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddAuthorAsync(Author author)
    {
        using var connection = _context.Connection();
        var query = "INSERT INTO authors (fullname, country, birthyear) VALUES (@fullname, @country, @birthyear)";
        var res = await connection.ExecuteAsync(query, author);
        return res>0;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        using var connection = _context.Connection();
        var query = $"delete from authors where id = @id";
        var res = await connection.ExecuteAsync(query, new{id});
        return res>0;
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        using var connection = _context.Connection();
        var query = $"select * from authors where id = @id";
        var author = await connection.QuerySingleAsync<Author>(query, new{id});
        return author;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        using var connection = _context.Connection();
        var query = $"select * from authors";
        var author = await connection.QueryAsync<Author>(query);
        return author.ToList();
    }



    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        using var connection = _context.Connection();
        var query = $"update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        var res = await connection.ExecuteAsync(query, author);
        return res>0;
    }
    public async Task<int> GetAuthorsAmountAsync()
    {
        using var connection = _context.Connection();
        var query = "select count(*) from authors";
        return await connection.ExecuteScalarAsync<int>(query);
    }
}