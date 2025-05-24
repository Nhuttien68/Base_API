using System;
using System.Collections.Generic;

namespace Tutorial.Repository.Entity;

public partial class Book
{
    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Publisher { get; set; }

    public DateTime PublishedDate { get; set; }

    public string Isbn { get; set; } = null!;

    public int Price { get; set; }

    public string? Description { get; set; }

    public Guid BookCategoryId { get; set; }

    public bool Status { get; set; }

    public virtual BookCategory BookCategory { get; set; } = null!;
}
