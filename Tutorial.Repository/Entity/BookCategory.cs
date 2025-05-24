using System;
using System.Collections.Generic;

namespace Tutorial.Repository.Entity;

public partial class BookCategory
{
    public Guid BookCategoyyId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Descriptions { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
