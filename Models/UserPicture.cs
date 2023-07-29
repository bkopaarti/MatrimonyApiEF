using System;
using System.Collections.Generic;

namespace MatrimonyApiEF.Models;

public partial class UserPicture
{
    public int UserId { get; set; }

    public string? Filepath { get; set; }

    public string? Type { get; set; }

    public virtual BasicInfo User { get; set; } = null!;
}
