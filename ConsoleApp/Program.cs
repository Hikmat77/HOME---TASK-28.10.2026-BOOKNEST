using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

var appDbContext = new AppDbContext();

var bookRepository = new BookRepository(appDbContext);
var bookService = new BookService(bookRepository);

var authorRepository = new AuthorRepository(appDbContext);
var authorService = new AuthorService(authorRepository);

var genreRepository = new GenreRepository(appDbContext);
var genreService = new GenreService(genreRepository);


while (true)
{
    System.Console.WriteLine("======================================");
    System.Console.WriteLine(@"--- MAIN MENU ---
--- BOOKS ---
1) Show All Books.
2) Show Book by id.
3) Add new Book.
4) Update Book.
5) Delete Book.
--- AUTHORS ---
6) Show All Authors.
7) Show Author by id.
8) Add new Author.
9) Update Author.
10) Delete Author.
--- GENRES ---
11) Show All Genres.
12) Show Genre by id.
13) Add new Genre.
14) Update Genre.
15) Delete Genre.
--- STATISTICS ---
16) Books amount.
17) Authors amount.
18) Genres amount.
19) Min published year by author.
20) Max published year by author.
21) Min published year by genre.
22) Max published year by genre.
23) Books amount by published year.
24) Books amount by genre.
0) Exit.");
    System.Console.Write("Choose --> ");
    var a = Console.ReadLine();
    System.Console.WriteLine("======================================");
    switch (a)
    {
        case "1":
        {
            var books = await bookService.GetBooksAsync();
            if (books.Data is not null)
            {
                foreach (var book in books.Data)
                {
                    System.Console.WriteLine($"{book.Id} | {book.Title} | {book.PublishedYear} | {book.TotalCopies}");
                }
            }
            break;
        }
        case "2":
            System.Console.Write("Enter book id --> ");
            var bookId = Convert.ToInt32(Console.ReadLine());
            await bookService.GetBookAsync(bookId);
            break;
        case "3":
            System.Console.Write("Enter Title --> ");
            var title = Console.ReadLine()!;
            System.Console.Write("Enter Published Year --> ");
            var year = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Total Copies --> ");
            var copies = Convert.ToInt32(Console.ReadLine());
            var newBook = new Book()
            {
                Title = title,
                PublishedYear = year,
                TotalCopies = copies
            };
            await bookService.AddBookAsync(newBook);
            break;
        case "4":
            System.Console.Write("Enter Id to update --> ");
            var uBookId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Title --> ");
            var uTitle = Console.ReadLine()!;
            System.Console.Write("Enter Published Year --> ");
            var uYear = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Total Copies --> ");
            var uCopies = Convert.ToInt32(Console.ReadLine());
            var updateBook = new Book()
            {
                Id = uBookId,
                Title = uTitle,
                PublishedYear = uYear,
                TotalCopies = uCopies
            };
            await bookService.UpdateBookAsync(updateBook);
            break;
        case "5":
            System.Console.Write("Enter id to delete --> ");
            var dBookId = Convert.ToInt32(Console.ReadLine());
            await bookService.DeleteBookAsync(dBookId);
            break;
        case "6":
        {
            var authors = await authorService.GetAuthorsAsync();
            if (authors.Data is not null)
            {
                foreach (var author in authors.Data)
                {
                    System.Console.WriteLine($"{author.Id} | {author.Fullname} | {author.Country} | {author.BirthYear}");
                }
            }
            break;
        }
        case "7":
            System.Console.Write("Enter author id --> ");
            var authorId = Convert.ToInt32(Console.ReadLine());
            await authorService.GetAuthorAsync(authorId);
            break;
        case "8":
            System.Console.Write("Enter Fullname --> ");
            var name = Console.ReadLine()!;
            System.Console.Write("Enter Country --> ");
            var country = Console.ReadLine()!;
            System.Console.Write("Enter Birth Year --> ");
            var birthYear = Convert.ToInt32(Console.ReadLine());
            var newAuthor = new Author()
            {
                Fullname = name,
                Country = country,
                BirthYear = birthYear
            };
            await authorService.AddAuthorAsync(newAuthor);
            break;
        case "9":
            System.Console.Write("Enter Id to update --> ");
            var uAuthorId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Fullname --> ");
            var uName = Console.ReadLine()!;
            System.Console.Write("Enter Country --> ");
            var uCountry = Console.ReadLine()!;
            System.Console.Write("Enter Birth Year --> ");
            var uBirthYear = Convert.ToInt32(Console.ReadLine());
            var updateAuthor = new Author()
            {
                Id = uAuthorId,
                Fullname = uName,
                Country = uCountry,
                BirthYear = uBirthYear
            };
            await authorService.UpdateAuthorAsync(updateAuthor);
            break;
        case "10":
            System.Console.Write("Enter id to delete --> ");
            var dAuthorId = Convert.ToInt32(Console.ReadLine());
            await authorService.DeleteAuthorAsync(dAuthorId);
            break;
        case "11":
            await genreService.GetAllGenresAsync();
            break;
        case "12":
            System.Console.Write("Enter genre id --> ");
            var genreId = Convert.ToInt32(Console.ReadLine());
            await genreService.GetGenreAsync(genreId);
            break;
        case "13":
            System.Console.Write("Enter Name --> ");
            var genreName = Console.ReadLine()!;
            var newGenre = new Genre()
            {
                Name = genreName
            };
            await genreService.AddGenreAsync(newGenre);
            break;
        case "14":
            System.Console.Write("Enter Id to update --> ");
            var uGenreId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter Name --> ");
            var uGenreName = Console.ReadLine()!;
            var updateGenre = new Genre()
            {
                Id = uGenreId,
                Name = uGenreName
            };
            await genreService.UpdateGenreAsync(updateGenre);
            break;
        case "15":
            System.Console.Write("Enter id to delete --> ");
            var dGenreId = Convert.ToInt32(Console.ReadLine());
            await genreService.DeleteGenreAsync(dGenreId);
            break;
        case "16":
            await bookService.GetBookAmountAsync();
            break;
        case "17":
            await authorService.GetAuthorsAmountAsync();
            break;
        case "18":
            await genreService.GetGenresAmountAsync();
            break;
        case "19":
            System.Console.Write("Enter author id --> ");
            var minAuthorId = Convert.ToInt32(Console.ReadLine());
            await bookService.GetMinPublishedYearByAuthorAsync(minAuthorId);
            break;
        case "20":
            System.Console.Write("Enter author id --> ");
            var maxAuthorId = Convert.ToInt32(Console.ReadLine());
            await bookService.GetMaxPublishedYearByAuthorAsync(maxAuthorId);
            break;
        case "21":
            System.Console.Write("Enter genre id --> ");
            var minGenreId = Convert.ToInt32(Console.ReadLine());
            await bookService.GetMinPublishedYearByGenreAsync(minGenreId);
            break;
        case "22":
            System.Console.Write("Enter genre id --> ");
            var maxGenreId = Convert.ToInt32(Console.ReadLine());
            await bookService.GetMaxPublishedYearByGenreAsync(maxGenreId);
            break;
        case "23":
            System.Console.Write("Enter published year --> ");
            var publishedYear = Convert.ToInt32(Console.ReadLine());
            await bookService.GetAmountByPublishedYearAsync(publishedYear);
            break;
        case "24":
            System.Console.Write("Enter genre id --> ");
            var amountGenreId = Convert.ToInt32(Console.ReadLine());
            await bookService.GetAmountByGenreAsync(amountGenreId);
            break;
        case "0":
            System.Console.WriteLine("Exiting....");
            return;
    }
}
