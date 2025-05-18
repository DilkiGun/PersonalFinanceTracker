using PersonalFinanceTracker.Application.Interfaces;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Infrastructure
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetByIdAsync(id);
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
        }
      
    }
}
