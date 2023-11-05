using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Library;

public class Book
{
    
    public string Title { get; set; }
    public string Author { get; set; }


    public Book(string title, string author)
    {
        this.Title = title;    
        this.Author = author;
    }

    public override string ToString()
    {
        return $"Title: {Title} Author: {Author}";
    }
}
