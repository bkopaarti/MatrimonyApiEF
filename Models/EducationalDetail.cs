using System;
using System.Collections.Generic;

namespace MatrimonyApiEF.Models;

public partial class EducationalDetail
{
    public int UserId { get; set; }

    public string? Educationalqulification { get; set; }

    public string? Incometype { get; set; }

    public string? Income { get; set; }

    public string? Occupation { get; set; }

    public string? Education { get; set; }

    public string? Profession { get; set; }

    public virtual BasicInfo? User { get; set; } = null!;
}
