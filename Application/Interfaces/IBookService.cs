using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBookAsync(Book book);
    Task<ApiResponse<bool>> UpdateBookAsync(Book book);
    Task<ApiResponse<bool>> DeleteBookAsync(int id);
    Task<ApiResponse<Book>> GetBookAsync(int id);
    Task<ApiResponse<List<Book>>> GetBooksAsync();
    Task<ApiResponse<int>> GetBookAmountAsync();
    Task<ApiResponse<int>> GetMinPublishedYearByAuthorAsync(int authorId);
    Task<ApiResponse<int>> GetMaxPublishedYearByAuthorAsync(int authorId);
    Task<ApiResponse<int>> GetMinPublishedYearByGenreAsync(int genreId);
    Task<ApiResponse<int>> GetMaxPublishedYearByGenreAsync(int genreId);
    Task<ApiResponse<int>> GetAmountByPublishedYearAsync(int year);
    Task<ApiResponse<int>> GetAmountByGenreAsync(int genreId);
}
