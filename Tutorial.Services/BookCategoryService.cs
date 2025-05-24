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
    public class BookCategoryService : IBookCategoryService
    {
        private BookCategoryRepository _bookCategoryRepository;

        public BookCategoryService()
        {
            _bookCategoryRepository = new BookCategoryRepository();
        }
        public async Task<CreateBookCategogyResponse> CreateBookCategory(CreateBookCategoryRequest request)
        {
            var bookCategory = new BookCategory
            {
                BookCategoyyId = Guid.NewGuid(),
                CategoryName = request.CategoryName,
                Descriptions = request.Description
            };
             await _bookCategoryRepository.CreateAsync(bookCategory);

            var response = new CreateBookCategogyResponse
            {
                CategoryName = bookCategory.CategoryName,
                Description = bookCategory.Descriptions
            };
             return response;

        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var bookCategory = await _bookCategoryRepository.GetByIdAsync(id);

            if (bookCategory == null)
            {
                return false; // Category not found
            }
            await _bookCategoryRepository.RemoveAsync(bookCategory);
            return true;

        }

        public async Task<List<GetBookCategoryRespone>> GetAllBookCategories()
        {
            var bookCategories =  await _bookCategoryRepository.GetAllAsync();
            List<GetBookCategoryRespone> bookCategoryResponses = new List<GetBookCategoryRespone>();
            foreach (var bookCategory in bookCategories)
            {
                GetBookCategoryRespone bookCategoryRespone = new GetBookCategoryRespone
                {
                    BookCategoryId = bookCategory.BookCategoyyId,
                    CategoryName = bookCategory.CategoryName,
                    Description = bookCategory.Descriptions,
                };
                bookCategoryResponses.Add(bookCategoryRespone);
            }
            return bookCategoryResponses;
        }
    }

}
