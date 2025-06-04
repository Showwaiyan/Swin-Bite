using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.Models;

namespace SwinBite.Controller
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("foods")]
        public async Task<IActionResult> GetAllBankAccounts()
        {
          List<Food> foods = await _context.Foods.ToListAsync();

          return Ok(foods);
        }
    } 
}
