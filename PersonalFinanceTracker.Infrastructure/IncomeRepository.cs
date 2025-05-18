using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Application.Interfaces;
using PersonalFinanceTracker.Domain.Entities;
using PersonalFinanceTracker.Infrastructure.Context;

namespace PersonalFinanceTracker.Infrastructure
{
    public class IncomeRepository:IIncomeRepository
    {
        public PersonalFinanceTrackerDbContext context { get; }
        public IncomeRepository(IDbContextFactory<PersonalFinanceTrackerDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Income income)
        {
            context.Incomes.Add(income);
            await context.SaveChangesAsync();
        }

        public Task<List<Income>> GetAllAsync()
        {
           var incomes = context.Incomes.ToListAsync();
            return incomes;
        }

        public async Task<Income?> GetByIdAsync(int id)
        {
            var income = await context.Incomes.FindAsync(id);
            return income;
        }

        public async Task UpdateAsync(Income income)
        {
            context.Incomes.Update(income);
            await context.SaveChangesAsync();
        }
    }
}
