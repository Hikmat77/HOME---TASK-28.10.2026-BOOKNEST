    using System.Net;
    using Application.Interfaces;
    using Application.Responses;
    using Domain.Interfaces;
    using Domain.Models;

    namespace Application.Services;

    public class BookService(IBookRepository bookRepository) : IBookService
    {
        private readonly IBookRepository repository = bookRepository;

        public async Task<ApiResponse<bool>> AddBookAsync(Book book)
        {
            var res = await repository.AddBookAsync(book);
            return res==true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
        }

        public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
        {
            var res = await repository.DeleteBookAsync(id);
            return res==true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
        }

        public async Task<ApiResponse<Book>> GetBookAsync(int id)
        {
            var res = await repository.GetBookAsync(id);
            return new ApiResponse<Book>(HttpStatusCode.OK, "Book with given id.", res);
        }

        public async Task<ApiResponse<List<Book>>> GetBooksAsync()
        {
            var res = await repository.GetBooksAsync();
            return new ApiResponse<List<Book>>(HttpStatusCode.OK, "List of books.", res);
        }

        public async Task<ApiResponse<bool>> UpdateBookAsync(Book book)
        {
            var res = await repository.UpdateBookAsync(book);
            return res==true
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
        }

        public async Task<ApiResponse<int>> GetBookAmountAsync()
        {
            var res = await repository.GetBookAmountAsync();
            return new ApiResponse<int>(HttpStatusCode.OK, "Books amount:", res);
        }

        public async Task<ApiResponse<int>> GetMinPublishedYearByAuthorAsync(int authorId)
        {
            var res = await repository.GetMinPublishedYearByAuthorAsync(authorId);
            return new ApiResponse<int>(HttpStatusCode.OK, "Min published year:", res);
        }

        public async Task<ApiResponse<int>> GetMaxPublishedYearByAuthorAsync(int authorId)
        {
            var res = await repository.GetMaxPublishedYearByAuthorAsync(authorId);
            return new ApiResponse<int>(HttpStatusCode.OK, "Max published year:", res);
        }

        public async Task<ApiResponse<int>> GetMinPublishedYearByGenreAsync(int genreId)
        {
            var res = await repository.GetMinPublishedYearByGenreAsync(genreId);
            return new ApiResponse<int>(HttpStatusCode.OK, "Min published year:", res);
        }

        public async Task<ApiResponse<int>> GetMaxPublishedYearByGenreAsync(int genreId)
        {
            var res = await repository.GetMaxPublishedYearByGenreAsync(genreId);
            return new ApiResponse<int>(HttpStatusCode.OK, "Max published year:", res);
        }

        public async Task<ApiResponse<int>> GetAmountByPublishedYearAsync(int year)
        {
            var res = await repository.GetAmountByPublishedYearAsync(year);
            return new ApiResponse<int>(HttpStatusCode.OK, "Books amount:", res);
        }

        public async Task<ApiResponse<int>> GetAmountByGenreAsync(int genreId)
        {
            var res = await repository.GetAmountByGenreAsync(genreId);
            return new ApiResponse<int>(HttpStatusCode.OK, "Books amount:", res);
        }
    }
