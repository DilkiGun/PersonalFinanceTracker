using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Application.Interfaces;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            try
            {
                var expenses = await _expenseService.GetAllExpensesAsync();
                return Ok(expenses);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllExpenses: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving expenses. Please try again later.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            try
            {
                var expense = await _expenseService.GetExpenseByIdAsync(id);
                if (expense == null) return NotFound();
                return Ok(expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetExpenseById: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving the expense. Please try again later.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromBody] Expense expense)
        {
            try
            {
                if (expense == null) return BadRequest("Expense cannot be null.");
                await _expenseService.AddExpenseAsync(expense);
                return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddExpense: {ex.Message}");
                return StatusCode(500, "An error occurred while adding the expense. Please try again later.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromBody] Expense expense)
        {
            try
            {
                if (expense == null) return BadRequest("Expense cannot be null.");
                var existingExpense = await _expenseService.GetExpenseByIdAsync(id);
                if (existingExpense == null) return NotFound();
                existingExpense.Value = expense.Value;
                existingExpense.Type = expense.Type;
                existingExpense.IncurredDate = expense.IncurredDate;
                await _expenseService.UpdateExpenseAsync(existingExpense);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateExpense: {ex.Message}");
                return StatusCode(500, "An error occurred while updating the expense. Please try again later.");
            }

        }
    }
}


