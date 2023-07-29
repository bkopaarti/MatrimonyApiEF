using System;
using System.Collections.Generic;

namespace MatrimonyApiEF.Models;

public partial class FamilyDetail
{
    public int Userid { get; set; }

    public string? Father { get; set; }

    public string? Mother { get; set; }

    public int? Brothers { get; set; }

    public int? Sisters { get; set; }

    public int? Marriedbrother { get; set; }

    public int? Marriedsister { get; set; }

    public string? RelativeContacts { get; set; }

    public string? Nativeplaceinsindh { get; set; }

    public string? Choiceoflifeparternaer { get; set; }

    public string? Familyincome { get; set; }

    public string? Incometype { get; set; }

    public virtual BasicInfo? User { get; set; } = null!;
}
