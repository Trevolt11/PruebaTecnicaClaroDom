using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClaroDomTest.Models;

namespace ClaroDomTest.Service
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<bool> UpdateBookAsync(int id, Book book);
        Task<bool> DeleteBookAsync(int id);
    }
}

