using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Application.Interfaces;
using PersonalFinanceTracker.Domain.Entities;
using PersonalFinanceTracker.Infrastructure.Context;

namespace PersonalFinanceTracker.Infrastructure
{
    public class ExpenseRepository : IExpenseRepository
    {
        public PersonalFinanceTrackerDbContext context { get; }
        public ExpenseRepository(IDbContextFactory<PersonalFinanceTrackerDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Expense expence)
        {
            context.Expenses.Add(expence);
            await context.SaveChangesAsync();
        }

        public Task<List<Expense>> GetAllAsync()
        {
            var expenses = context.Expenses.ToListAsync();
            return expenses;
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            var expense = await context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            return expense;
        }

        public async Task UpdateAsync(Expense expense)
        {
            context.Entry(expense).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
