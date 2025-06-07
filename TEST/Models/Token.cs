using System;
using System.Collections.Generic;

namespace PANAMA.Models;

public partial class Token
{
    public int IdToken { get; set; }

    public int AccountId { get; set; }

    public string Token1 { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;

    public DateTime Expiration { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;
}
