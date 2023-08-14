using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LUMAApp.Entities
{
    public class Employee
    {
        [Required]
        [Key]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string? EMail { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string? EmployeeName { get; set; }

        [Required]

        public string? PasswordHashed { get; set; }
    }
}
