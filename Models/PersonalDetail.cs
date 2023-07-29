using System;
using System.Collections.Generic;

namespace MatrimonyApiEF.Models;

public partial class PersonalDetail
{
    public int UserId { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public string? Timeofbirth { get; set; }

    public string? Placeofbirth { get; set; }

    public string? Height { get; set; }

    public string? Weight { get; set; }

    public string? Bloodgroup { get; set; }

    public string? Built { get; set; }

    public string? Color { get; set; }

    public string? Manglik { get; set; }

    public string? MarrigeStatus { get; set; }

    public string? Disease { get; set; }

    public string? Lens { get; set; }

    public string? Hobbies { get; set; }

    public string? Diet { get; set; }

    public virtual BasicInfo? User { get; set; } = null!;
}
