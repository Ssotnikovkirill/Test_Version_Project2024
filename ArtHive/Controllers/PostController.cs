using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class PostController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public PostController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //для создания нового поста
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        post.UserId = _userManager.GetUserId(User); //получаем ID текущего пользователя
        post.IsApproved = false; //пост должен быть одобрен администратором перед публикацией
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    //для получения поста по ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        return post;
    }

    //для одобрения поста администратором
    [HttpPost("{id}/approve")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> ApprovePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        post.IsApproved = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    //для получения постов по категории
    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Post>>> GetPostsByCategory(string category)
    {
        return await _context.Posts.Where(p => p.Category == category && p.IsApproved).ToListAsync();
    }

    //для сохранения поста
    [HttpPost("{postId}/save")]
    public async Task<IActionResult> SavePost(int postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null)
        {
            return NotFound();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user.SavedPosts == null)
        {
            user.SavedPosts = new List<Post>();
        }

        user.SavedPosts.Add(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }

//для создания нового поста
    [HttpPost("create")]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post post)
    {
        post.UserId = _userManager.GetUserId(User); //получаем ID текущего пользователя
        post.IsApproved = false; //пост должен быть одобрен администратором перед публикацие
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);

 
    }

    //для установки рейтинга
    [HttpPost("setrate")]
    public async Task<IActionResult> SetRate([FromBody] int rate)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null)
        {
            return NotFound();
        }

        post.Rate = rate;
        await _context.SaveChangesAsync();

        return NoContent();
    }

//для фильтрации рекомендаций
    [HttpGet("recommendation/filter")]
    public async Task<ActionResult<IEnumerable<Post>>> FilterRecommendations([FromBody] Post post)
    {
        return await _context.Posts
            .Where(p => p.Category == filter.Category && p.Type == filter.Type && p.IsApproved)
            .ToListAsync();
    }
}

