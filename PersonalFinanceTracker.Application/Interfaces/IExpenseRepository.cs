using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Application.Interfaces
{
    public interface IExpenseRepository
    {
        Task AddAsync(Expense expence);
        Task<List<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(int id);
        Task UpdateAsync(Expense expense);
    }
}
