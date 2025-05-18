using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Repository.Response
{
    public class CreateBookResponse
    {
       public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Price { get; set; }
    }
}
