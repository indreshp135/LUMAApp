using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class EmpMaster
{
    public string EmpId { get; set; } = null!;

    public string? EmpName { get; set; }

    public string? Desgn { get; set; }

    public string? Dept { get; set; }

    public string? Gender { get; set; }

    public DateTime? Dob { get; set; }

    public DateTime? Doj { get; set; }

    public virtual ICollection<EmployeeCardDetail> EmployeeCardDetails { get; set; } = new List<EmployeeCardDetail>();

    public virtual ICollection<EmployeeIssueDetail> EmployeeIssueDetails { get; set; } = new List<EmployeeIssueDetail>();
}
