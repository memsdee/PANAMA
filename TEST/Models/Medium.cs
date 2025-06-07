using System;
using System.Collections.Generic;

namespace PANAMA.Models;

public partial class Medium
{
    public int IdMedia { get; set; }

    public string FilePath { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public int? Idproject { get; set; }

    public virtual Project? IdprojectNavigation { get; set; }
}
