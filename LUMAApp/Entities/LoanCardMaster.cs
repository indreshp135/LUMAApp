using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class LoanCardMaster
{
    public string LoanId { get; set; } = null!;

    public string LoanType { get; set; } = null!;

    public int? DurationYears { get; set; }

    public virtual ICollection<EmployeeCardDetail> EmployeeCardDetails { get; set; } = new List<EmployeeCardDetail>();

    public virtual ICollection<ItemMaster> ItemMasters { get; set; } = new List<ItemMaster>();
}
