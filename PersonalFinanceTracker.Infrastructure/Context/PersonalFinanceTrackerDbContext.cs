using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Infrastructure.Context
{
    public class PersonalFinanceTrackerDbContext: DbContext
    {
        public PersonalFinanceTrackerDbContext(DbContextOptions<PersonalFinanceTrackerDbContext> options) : base(options)
        {
        }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }    
}
