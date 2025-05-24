using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Repository.Request;
using Tutorial.Repository.Response;

namespace Tutorial.Services
{
    public interface IBookCategoryService
    {
        Task<CreateBookCategogyResponse> CreateBookCategory(CreateBookCategoryRequest request);

        Task<List<GetBookCategoryRespone>> GetAllBookCategories();

        Task<bool> DeleteCategory(Guid id);

    }
}
