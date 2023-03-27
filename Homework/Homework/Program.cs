using Core.Entities;
using Utils.Exceptions;

try
{
    Book book1 = new("book1", "author1", 40);
    Book book2 = new("book2", "author2", 20);
    Book book3 = new("book3", "author3", 50);
    Book book4 = new("book4", "author4", 10);
    Book book5 = new("book5", "author4", 10);

    Library library = new(4);

    library.AddBook(book1);
    library.AddBook(book2);
    library.AddBook(book3);
    library.AddBook(book4);

    //Console.WriteLine(library.GetBookById(2).ShowInfo());

    foreach (var book in library.GetAllBooks())
    {
        Console.WriteLine(book.ShowInfo());
    }

    Console.WriteLine("-------");

    library.Sort();

    foreach (var book in library.GetAllBooks())
    {
        Console.WriteLine(book.ShowInfo());
    }

    library.DeleteBookById(1);
    Console.WriteLine(library.GetBookById(1).ShowInfo());
}
catch (CapacityLimitException ex)
{
    Console.WriteLine(ex.Message);
}
catch(NotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch(AlreadyExistsException ex)
{
    Console.WriteLine(ex.Message);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}