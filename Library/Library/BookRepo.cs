using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library;

public static class BookRepo
{

    
    private static List<Book> books = new List<Book>();

    public static List<Book> Show()
    {
        return books;
    }

    public static List<Book> Add(string title, string author)
    {
       if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author))
       {
            books.Add(new Book(title,author));
            
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
        if(index >= 0 && index < books.Count -1 && book != null) 
        {
            books[index] = book;
        }

        return books;

    }

}
