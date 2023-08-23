namespace LUMAApp.Models
{
    public class UserTablesRequest
    {
        public string? EmployeeId { get; set; }
    }

    public class Loan
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public int? Duration { get; set; }
        public DateTime? IssueDate { get; set; }
    }

    public class Item
    {
        public string? Id { get; set; }
        public string? Category { get; set; }

        public int? Valuation { get; set; }

        public string?Make { get; set; }

        public string? Description { get; set; }
    }


    public class UserTablesResponse
    {
        public ICollection<Loan>? LoanTable { get; set; }
        public ICollection<Item>? ItemTable { get; set; }

    }

    public class UserFormRequest
    {
        public string? LoanId { get; set; }

        public string? ItemId { get; set; }

        public string? EmployeeId { get; set; }
    }

    public class ItemsForLoanTypeRequest
    {
        public string? LoanType { get; set; }
    }
}
