using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Repository.Entity;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;
using Tutorial.Services;

namespace Tutorial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public async Task<CreateBookResponse> CreateBook(CreateBookRequest request)
        {
            return await _bookService.CreateBook(request);
        }

        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }
        [HttpGet("{id}")]
        public async Task<Book> GetBookById(Guid id)
        {
            return await _bookService.GetBookById(id);
        }
        [HttpPut("{id}")]
        public async Task<bool> UpdateBook(Guid id, CreateBookRequest request)
        {
            return await _bookService.UpdateBook(id, request);
        }
    }
}
