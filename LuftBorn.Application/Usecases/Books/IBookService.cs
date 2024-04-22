using LuftBorn.Application.Dtos.Books;
using LuftBorn.Domain.Shared;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LuftBorn.Application.Usecases.Books
{
    public interface IBookService
    {
        IQueryable<BookDto> GetAllBooks();
        Task<BookDto> GetBookById(Guid id, CancellationToken cancellationToken = default);
        Task<SuccessMessageDto> InsertNewBook(BookDto bookDto);
        Task<SuccessMessageDto> UpdateBook(BookDto bookDto);
        Task<SuccessMessageDto> DeleteBook(Guid id);  
    }
}
