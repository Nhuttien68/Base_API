using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Repository.Entity;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;
namespace Tutorial.Services
{
    public interface IBookService
    {
        Task<CreateBookResponse> CreateBook(CreateBookRequest request);
        Task<List<Book>> GetAllBooks();
         Task<Book> GetBookById(Guid id);
        Task<bool> UpdateBook(Guid id, CreateBookRequest request);

        Task<bool> DeleteBook(Guid id);

    }
}
