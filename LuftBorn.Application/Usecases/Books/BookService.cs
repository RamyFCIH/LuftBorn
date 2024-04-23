using LuftBorn.Application.Dtos.Books;
using LuftBorn.Domain.Books;
using LuftBorn.Domain.Shared;
using Sela.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LuftBorn.Application.Usecases.Books
{
    public sealed class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
        }

        public IQueryable<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAll();
            return books.Select(x => new BookDto
            {
                Id = x.Id,
                Name = x.Name,
                PublishedDate = x.PublishedDate,
                Description = x.Description
            });

        }

        public async Task<BookDto> GetBookById(Guid id, CancellationToken cancellationToken)
        {
            var bookModel = await _bookRepository.GetByIdAsync(id, cancellationToken);
            return new BookDto
            {
                Id = bookModel.Id,
                Name = bookModel.Name,
                PublishedDate = bookModel.PublishedDate,
                Description = bookModel.Description
            };

        }
        public async Task<SuccessMessageDto> InsertNewBook(BookDto bookDto)
        {
            if (bookDto is null || string.IsNullOrEmpty(bookDto.Name))
            {
                return new SuccessMessageDto { IsSuccess = false, Message = "Name of the Book is required" };
            }
            _bookRepository.Add(Book.Create(Guid.NewGuid(), bookDto.Name, bookDto.Description, bookDto.PublishedDate));

            var noOfAffectedRows = await _unitOfWork.SaveChangesAsync();

            if (noOfAffectedRows > 0)
            {
                return new SuccessMessageDto { IsSuccess = true, Message = "Book Is Added Successfully" };
            }
            return new SuccessMessageDto { IsSuccess = false, Message = "Failed to add the new book" };
        }

        public async Task<SuccessMessageDto> UpdateBook(BookDto bookDto)
        {
            var bookInDb = await _bookRepository.GetByIdAsync(bookDto.Id);

            if (bookInDb is null)
            {
                return new SuccessMessageDto { IsSuccess = false, Message = "This Book is not found" };
            }

            if (bookDto is null || string.IsNullOrEmpty(bookDto.Name))
            {
                return new SuccessMessageDto { IsSuccess = false, Message = "Name of the Book is required" };
            }

            bookInDb = Book.Edit(bookInDb.Id, bookDto.Name, bookDto.Description, bookDto.PublishedDate);
            _bookRepository.Update(bookInDb);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessMessageDto { IsSuccess = true, Message = "Book is Updated successfully" };
        }
        public async Task<SuccessMessageDto> DeleteBook(Guid id)
        {
            var bookInDb = await _bookRepository.GetByIdAsync(id);

            if (bookInDb is null)
            {
                return new SuccessMessageDto { IsSuccess = false, Message = "This Book is not found" };
            }
            _bookRepository.Delete(bookInDb);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessMessageDto { IsSuccess = true, Message = "Book is deleted successfully" };
        }

    }
}
