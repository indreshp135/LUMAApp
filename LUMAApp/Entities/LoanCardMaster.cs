using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class LoanCardMaster
{
    public string LoanId { get; set; } = null!;

    public string? LoanType { get; set; }

    public int? DurationYears { get; set; }

}
