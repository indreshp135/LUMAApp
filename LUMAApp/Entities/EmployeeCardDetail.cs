using System;
using System.Collections.Generic;

namespace LUMAApp.Entities;

public partial class EmployeeCardDetail
{
    public string EmpId { get; set; } = null!;

    public string LoanId { get; set; } = null!;

    public DateTime? CardIssueDate { get; set; }

    public virtual EmpMaster Emp { get; set; } = null!;

    public virtual LoanCardMaster Loan { get; set; } = null!;
}
