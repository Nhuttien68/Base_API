using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Repository.Response
{
    public class GetBookCategoryRespone
    {
        public Guid BookCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; } 
    }
}
