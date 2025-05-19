using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Application.Interfaces
{
    public  interface IIncomeRepository
    {
        Task AddAsync(Income income);
        Task<List<Income>> GetAllAsync();
        Task<Income?> GetByIdAsync(int id);
        Task UpdateAsync(Income income);
    }
}
