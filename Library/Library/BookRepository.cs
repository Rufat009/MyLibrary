using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library;

public static class BookRepository
{
    private static List<Book> books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText("../../../Books.json")) ?? new List<Book>();

    public static List<Book> Show() => books;

    public static List<Book> Add(string title, string author, string content)
    {
        if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(content))
        {
            books.Add(new Book(title, author,content));

        }

        return books;
    }


    public static List<Book> Delete(Book book)
    {
        books.Remove(book);

        return books;

    }

    public static List<Book> Search(string title)
    {
        List<Book> listBook = new List<Book>();

        foreach (Book book in books)
        {
            if (book.Title.Contains(title))
            {
                listBook.Add(book);
            }
        }
        return listBook;

    }

    public static List<Book> Edit(int index, Book book)
    {
        if (index >= 0 && index < books.Count - 1 && book != null)
        {
            books[index] = book;
        }

        return books;

    }

}
