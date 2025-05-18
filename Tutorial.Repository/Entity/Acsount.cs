using System;
using System.Collections.Generic;

namespace Tutorial.Repository.Entity;

public partial class Acsount
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Active { get; set; }
}
