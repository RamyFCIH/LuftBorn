using LuftBorn.Domain.Books;

namespace LuftBorn.Infrastructure.Repositories
{
    public sealed class BookRepository : Repository<Book>, IBookRepository
    {

        public BookRepository(ApplicationDbContext context) 
            : base(context)
        {
                
        }
    }
}
