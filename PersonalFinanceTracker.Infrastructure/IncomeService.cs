using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinanceTracker.Application.Interfaces;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Infrastructure
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<List<Income>> GetAllIncomesAsync()
        {
            return await _incomeRepository.GetAllAsync();
        }

        public async Task<Income?> GetIncomeByIdAsync(int id)
        {
            return await _incomeRepository.GetByIdAsync(id);
        }

        public async Task AddIncomeAsync(Income income)
        {
            await _incomeRepository.AddAsync(income);
        }

        public async Task UpdateIncomeAsync(Income income)
        {
            await _incomeRepository.UpdateAsync(income);
        }
      
    }
}
