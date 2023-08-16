using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class EmpIssueDetail
{
    public string IssueId { get; set; } = null!;

    public string? EmpId { get; set; }

    public string ItemId { get; set; } = null!;

    public DateTime? IssueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual EmpMaster? Emp { get; set; }

    public virtual ItemMaster? ItemMaster { get; set; }
}
