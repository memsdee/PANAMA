using System;
using System.Collections.Generic;

namespace PANAMA.Models;

public partial class Project
{
    public int IdProject { get; set; }

    public string Category { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateTime TimeProject { get; set; }

    public string DescProject { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public virtual ICollection<Medium> Media { get; set; } = new List<Medium>();
}
