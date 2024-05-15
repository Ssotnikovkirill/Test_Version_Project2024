// mодель представляет категорию, к которой может быть привязан пост
// она содержит название(имя) категории и список постов в этой категории
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
}