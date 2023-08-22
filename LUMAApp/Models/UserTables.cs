namespace LUMAApp.Models
{
    public class UserTablesRequest
    {
        public string? EmployeeId { get; set; }
    }

    public class Loan
    {
        public string? LoanId { get; set; }
        public string? LoanType { get; set; }
        public int LoanDuration { get; set; }
        public DateTime CardIssueDate { get; set; }
    }

    public class Item
    {
        public string? ItemId { get; set; }
        public string? ItemCategory { get; set; }

        public int ItemValuation { get; set; }

        public string? ItemMake { get; set; }

        public string? ItemDescription { get; set; }
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
