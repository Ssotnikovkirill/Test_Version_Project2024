//модель комментария: содержание комментария, автор комментария и пост, к которому был добавлен комментарий
public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public ApplicationUser Author { get; set; }
    public Post Post { get; set; }
}