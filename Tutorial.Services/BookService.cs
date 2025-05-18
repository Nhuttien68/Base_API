using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Repository.Entity;
using Tutorial.Repository.Repository;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;

namespace Tutorial.Services
{
    public class BookService : IBookService
    {
        private BookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }
        public async Task<CreateBookResponse> CreateBook(CreateBookRequest request)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                Publisher = request.Publisher,
                PublishedDate = request.PublishedDate,
                Isbn = request.Isbn,
                Genre = request.Genre,
                Price = request.Price,
                Description = request.Description
            };
             await _bookRepository.CreateAsync(book); 

            var response = new CreateBookResponse
            {
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate,
                Isbn = book.Isbn,
                Genre = book.Genre,
                Price = book.Price,
                Description = book.Description
            };
             return response;
        }


    }
}
