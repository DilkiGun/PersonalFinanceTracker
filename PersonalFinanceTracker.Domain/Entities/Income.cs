
using System.ComponentModel.DataAnnotations;
using PersonalFinanceTracker.Domain.Enums;

namespace PersonalFinanceTracker.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public IncomeType Type { get; set; }
        public DateTime IncurredDate { get; set; } = DateTime.Now;
    }
}
