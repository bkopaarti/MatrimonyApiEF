using System;
using System.Collections.Generic;

namespace MatrimonyApiEF.Models;

public partial class BasicInfo
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public int? Pincode { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public virtual EducationalDetail? EducationalDetail { get; set; }

    public virtual FamilyDetail? FamilyDetail { get; set; }

    public virtual ParnterPreferenceDetail? ParnterPreferenceDetail { get; set; }

    public virtual PersonalDetail? PersonalDetail { get; set; }

    public virtual UserPicture? UserPicture { get; set; }
}
