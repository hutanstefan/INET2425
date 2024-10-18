using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore; // Don't forget to include this
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
                return book.Id;
            }
            return Guid.Empty;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }


        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            var existingBook = await context.Books.FindAsync(book.Id);
            if (existingBook != null)
            {
                context.Entry(existingBook).CurrentValues.SetValues(book);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Book not found"); 
            }
        }
    }
}
