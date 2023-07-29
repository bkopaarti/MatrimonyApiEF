using System;
using System.Collections.Generic;

namespace MatrimonyApiEF.Models;

public partial class ParnterPreferenceDetail
{
    public int UserId { get; set; }

    public string? AgeRange { get; set; }

    public string? HeightRange { get; set; }

    public string? MarritalStatus { get; set; }

    public string? CountryLivingIn { get; set; }

    public string? StateLivingIn { get; set; }

    public string? Qualification { get; set; }

    public string? Profession { get; set; }

    public string? AnnualIncome { get; set; }

    public string? Diet { get; set; }

    public virtual BasicInfo? User { get; set; } = null!;
}
