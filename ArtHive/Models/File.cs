// модель представляет файл, который user может прикрепить к посту

public class FileModel
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[] Data { get; set; }
    public Post Post { get; set; }
}