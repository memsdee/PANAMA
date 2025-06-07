using System;
using System.Collections.Generic;

namespace PANAMA.Models;

public partial class Sponsor
{
    public int IdSponsor { get; set; }

    public string Name { get; set; } = null!;

    public string LogoPath { get; set; } = null!;
}
