using LuftBorn.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Sela.Domain.Interfaces;


namespace LuftBorn.Infrastructure
{

    public sealed class ApplicationDbContext : DbContext , IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
       
        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
       
    }
}