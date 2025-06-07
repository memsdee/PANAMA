using System;
using System.Collections.Generic;

namespace PANAMA.Models;

public partial class Account
{
    public int IdAccount { get; set; }

    public string AdminName { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
