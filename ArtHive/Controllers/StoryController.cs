using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class StoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("active")]
    public async Task<ActionResult<Story>> GetActiveStory()
    {
        // код здесь...
    }
}
