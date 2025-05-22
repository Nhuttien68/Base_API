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

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} was not found.");
            }
            
            return book;
        }

        public async Task<bool> UpdateBook(Guid id, CreateBookRequest request)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} was not found.");
            }

            // Update the book properties
            book.Title = request.Title;
            book.Author = request.Author;
            book.Publisher = request.Publisher;
            book.PublishedDate = request.PublishedDate;
            book.Isbn = request.Isbn;
            book.Genre = request.Genre;
            book.Price = request.Price;
            book.Description = request.Description;

            // Save the updated book
            await _bookRepository.UpdateAsync(book);
            return true;
        }
    }
}
