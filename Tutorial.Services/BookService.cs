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
                BookId = Guid.NewGuid(),
                BookCategoryId = request.BookCategoryId,
                Status = true,
                Title = request.Title,
                Author = request.Author,
                Publisher = request.Publisher,
                PublishedDate = request.PublishedDate,
                Isbn = request.Isbn,
                Price = request.Price,
                Description = request.Description
            };
             await _bookRepository.CreateAsync(book); 

            var response = new CreateBookResponse
            {
                BookCategoryId = book.BookCategoryId,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublishedDate = book.PublishedDate,
                Isbn = book.Isbn,
                Price = book.Price,
                Description = book.Description
            };
             return response;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return false; 
            }
            book.Status = false;
             await _bookRepository.UpdateAsync(book);// dùng update!!!
             return true; // Trả về true nếu xóa thành công
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
            book.Title = string.IsNullOrEmpty(request.Title) ? book.Title : request.Title;
            book.Author = request.Author;
            book.Publisher = request.Publisher;
            book.PublishedDate = request.PublishedDate;
            book.Isbn = request.Isbn;
            book.Price = request.Price;
            book.Description = request.Description;

            // Save the updated book
            await _bookRepository.UpdateAsync(book);
            return true;
        }
    }
}
