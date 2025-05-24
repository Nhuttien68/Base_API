using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;
using Tutorial.Services;

namespace Tutorial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }
        [HttpPost]
        public async Task<CreateBookCategogyResponse> CreateBookCategory(CreateBookCategoryRequest request)
        {
            return await _bookCategoryService.CreateBookCategory(request);
        }
        [HttpGet]
        public async Task<List<GetBookCategoryRespone>> GetAllBookCategories()
        {
            return await _bookCategoryService.GetAllBookCategories();
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteCategory([FromRoute] Guid id)
        {
            return await _bookCategoryService.DeleteCategory(id);
        }
    }
}