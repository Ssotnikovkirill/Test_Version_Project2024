using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public List<Post> Posts { get; set; }
    public string UserRole { get; set; }
    public string Picture { get; set; }
    public string Description { get; set; }
    public List<Post> SavedPosts { get; set; }
    public List<Post> WrittenPosts { get; set; }
    public int Subscribers { get; set; }
}

