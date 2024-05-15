using Microsoft.AspNetCore.Identity;
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Category { get; set; } //BackEnd, FrontEnd, Программирование, Дизайн
    public bool IsApproved { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string Picture { get; set; }
    public string Type { get; set; } //сухая, обучающая, развлекательная
    public int Rate { get; set; }
    public ICollection<FileModel> Files { get; set; }
    public TimeSpan AverageTime { get; set; }
    //public DateTime DateCreated { get; set; }
    public ICollection<Comment> Comments { get; set; } //комментарии к посту
    public string NeeroDescription { get; set; }
}
