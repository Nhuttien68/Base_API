using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public async Task<List<CreateBookResponse>> GetAllBooks()
        //{
        //    return await _bookService.GetAllBooks();
        //}
    }
}
