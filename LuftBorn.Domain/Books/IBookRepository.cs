using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LuftBorn.Domain.Books
{
    public interface IBookRepository
    {

        /// <summary>
        /// Getting Book By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Book?> GetByIdAsync(Guid id, CancellationToken cancellationToken=default);

        /// <summary>
        /// Getting All Books
        /// </summary>
        /// <returns></returns>
        IQueryable<Book> GetAll();


        /// <summary>
        /// Insert New Book
        /// </summary>
        /// <param name="book"></param>
        void Add(Book book);

        /// <summary>
        /// Update Existing Book Data
        /// </summary>
        /// <param name="book"></param>
        void Update(Book book);


        /// <summary>
        /// Delete Book By Id
        /// </summary>
        /// <param name="book"></param>
        void Delete(Book book);
    }
}
