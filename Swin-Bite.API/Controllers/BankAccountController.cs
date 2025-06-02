using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Controllers
{
    [Route("bankaccount/")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        // AppDbContext Injections
        private readonly AppDbContext _context;

        // Constructor
        public BankAccountController(AppDbContext context) // Controller Injection
        {
            _context = context;
        }

        // Account Validate Route
        [HttpGet("validate/{accountNumber}")]
        public async Task<IActionResult> ValidateAccount(string accountNumber)
        {
            try
            {
                // Checking account Number is in BankAccount DB
                BankAccount userAccount = await _context.BankAccounts.FirstOrDefaultAsync(b =>
                    b.AccountNumber == accountNumber
                );

                if (userAccount == null)
                {
                    return NotFound(
                        new
                        {
                            status = 404,
                            message = "Bank Account NotFound",
                        }
                    );
                }
                int userAge = 18; // Only for testing
                if (userAge < userAccount.AgeRestriction)
                {
                    return BadRequest(new
                    {
                        status = 400,
                        message = "Age Restriction not met",
                    });
                }

                var result = new
                {
                    status = 200,
                    message = "Bank Account Found",
                    data = userAccount,
                };
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { status = 500, message = $"Error: {ex.Message}" });
            }
        }
    }
}
