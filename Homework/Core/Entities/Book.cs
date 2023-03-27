using Core.Interfaces;

namespace Core.Entities;

public class Book : IEntity
{
    private static int _id;

    public int Id { get; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
    public bool IsDeleted { get; set; }

    public Book(string name, string authorName, int pageCount)
    {
        Id = ++_id;
        Name = name;
        AuthorName = authorName;
        PageCount = pageCount;
    }

    public string ShowInfo()
    {
        return $"{Id} - {Name} - {AuthorName} - {PageCount} - {IsDeleted}";
    }

    public static bool operator >(Book book1, Book book2)
    {
        return book1.PageCount > book2.PageCount;
    }

    public static bool operator <(Book book1, Book book2)
    {
        return book1.PageCount < book2.PageCount;
    }
}
