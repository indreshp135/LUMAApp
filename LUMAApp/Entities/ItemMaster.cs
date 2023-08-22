using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class ItemMaster
{
    public string ItemId { get; set; } = null!;

    public string? ItemDescp { get; set; }

    public string? ItemStatus { get; set; }

    public string? ItemMake { get; set; }

    public string? ItemCategory { get; set; }

    public int? ItemValuation { get; set; }

    public virtual ICollection<EmployeeIssueDetail> EmployeeIssueDetails { get; set; } = new List<EmployeeIssueDetail>();

    public virtual LoanCardMaster? ItemCategoryNavigation { get; set; }
}
