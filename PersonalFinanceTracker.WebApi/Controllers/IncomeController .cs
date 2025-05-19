using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Application.Interfaces;
using PersonalFinanceTracker.Domain.Entities;
using PersonalFinanceTracker.Infrastructure;

namespace PersonalFinanceTracker.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeById(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);
            if (income == null) return NotFound();
            return Ok(income);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] Income income)
        {
            await _incomeService.AddIncomeAsync(income);
            return CreatedAtAction(nameof(GetIncomeById), new { id = income.Id }, income);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(int id, [FromBody] Income income)
        {
            if (income == null) return BadRequest("Income cannot be null.");
            var existingIncome=await  _incomeService.GetIncomeByIdAsync(id);
            if (existingIncome == null) return NotFound();
            existingIncome.Value = income.Value;
            existingIncome.Type = income.Type;
            existingIncome.IncurredDate = income.IncurredDate;
            await _incomeService.UpdateIncomeAsync(existingIncome);
            return NoContent();
        }
    }
}


