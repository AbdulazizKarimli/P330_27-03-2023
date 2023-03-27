using Core.Interfaces;
using Utils.Exceptions;

namespace Core.Entities;

public class Library : IEntity
{
    private static int _id;

    public int Id { get; }
    public int BookLimit { get; set; }
    private Book[] _books;

    public Library(int bookLimit)
    {
        Id = ++_id;
        BookLimit = bookLimit;
        _books = new Book[0];
    }

    public void AddBook(Book newBook)
    {
        if (_books.Length == BookLimit)
            throw new CapacityLimitException("Limit dolub.");

        foreach (var book in _books)
        {
            if (!book.IsDeleted && book.Name == newBook.Name)
                throw new AlreadyExistsException("Bu adda kitab var");
        }

        Array.Resize(ref _books, _books.Length + 1);
        _books[^1] = newBook;
    }

    public Book GetBookById(int id)
    {
        foreach (var book in _books)
        {
            if(!book.IsDeleted && book.Id == id)
                return book;
        }

        throw new NotFoundException("Bele bir kitab yoxdur");
    }

    public Book[] GetAllBooks()
    {
        Book[] copyBooks = new Book[_books.Length];

        for (int i = 0; i < copyBooks.Length; i++)
        {
            copyBooks[i] = _books[i];
        }

        return copyBooks;
    }

    public void DeleteBookById(int id) //5
    {
        //1,2,3,5
        foreach (var book in _books)
        {
            if (!book.IsDeleted && book.Id == id)
            {
                book.IsDeleted = true;
                return;
            }
        }

        throw new NotFoundException("Bele bir kitab yoxdur");
    }

    public void Sort()
    {
        //1,2,5,3,7
        //1,2,3,5,7

        for (int i = 0; i < _books.Length; i++)
        {
            for (int j = 1; j < _books.Length - i; j++)
            {
                //2,1,4,5
                if (_books[j - 1] > _books[j])
                {
                    Book temp = _books[j]; //temp = 1
                    _books[j] = _books[j - 1]; //_books[1] = 2
                    _books[j - 1] = temp; //_books[0] = 1
                }
            }
        }
    }
}