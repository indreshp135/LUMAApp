using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class EmployeeIssueDetail
{
    public string? EmpId { get; set; }

    public string? ItemId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string IssueId { get; set; } = null!;

    public virtual EmpMaster? Emp { get; set; }

    public virtual ItemMaster? Item { get; set; }
}
