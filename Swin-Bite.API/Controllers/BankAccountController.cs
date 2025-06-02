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
                    return StatusCode(
                        404,
                        new
                        {
                            status = 404,
                            message = "Bank Account NotFound",
                            data = userAccount,
                        }
                    );
                }
                var result = new
                {
                    status = 200,
                    message = "Bank Account Found",
                    data = userAccount,
                };
                return StatusCode(200, result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new { status = 500, message = $"Error: {ex.Message}" });
            }
        }
    }
}
