using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.DTO;
using SwinBite.Models;

namespace SwinBite.Controller
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
