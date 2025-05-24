using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Repository.Request
{
    public class CreateBookCategoryRequest
    {
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
