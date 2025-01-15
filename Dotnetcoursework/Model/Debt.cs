using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnetcoursework.Model
{
    public class Debts
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Unique identifier for each debt

        [Required(ErrorMessage = "Debt Source is required.")]
        [StringLength(100, ErrorMessage = "Debt Source cannot exceed 100 characters.")]
        public string DebtSource { get; set; } = string.Empty; // Source of the debt

        [Required(ErrorMessage = "Debt Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public double DebtAmount { get; set; } // Amount of debt

        [Required(ErrorMessage = "Debt Due Date is required.")]
        [DataType(DataType.Date)]
        public DateTime DebtDueDate { get; set; } = DateTime.Today.AddDays(1); // Due date of the debt

        public bool IsCleared { get; set; } = false; // Status of the debt (cleared or not)
    }
}
