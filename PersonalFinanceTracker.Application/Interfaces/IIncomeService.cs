using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Application.Interfaces
{
    public interface IIncomeService
    {
        Task<List<Income>> GetAllIncomesAsync();
        Task<Income?> GetIncomeByIdAsync(int id);
        Task AddIncomeAsync(Income income);
        Task UpdateIncomeAsync(Income income);
     
    }
}
