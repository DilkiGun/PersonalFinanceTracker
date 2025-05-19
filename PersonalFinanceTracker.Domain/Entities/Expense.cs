
using System.ComponentModel.DataAnnotations;
using PersonalFinanceTracker.Domain.Enums;

namespace PersonalFinanceTracker.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please provide a value")]
        public decimal Value { get; set; }
        [Required]
        [EnumDataType(typeof(ExpenseType),ErrorMessage="Please select an expense type")]
        public ExpenseType Type { get; set; }
        public DateTime IncurredDate { get; set; } = DateTime.Now;
    }    
}
