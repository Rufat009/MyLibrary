using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library;

/// <summary>
/// Interaction logic for ShowBook.xaml
/// </summary>
public partial class ShowBook : Window, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;
    BooksWindow booksWindow;
    Book book;

    public ShowBook(BooksWindow booksWindow, Book book)
    {
        InitializeComponent();

        this.booksWindow = booksWindow;
        TitleTextBox = book.Title;
        AuthorTextBox = book.Author;
        ContentTextBox = book.Content;
        DataContext = this;
    }


    private string contentTextBox;

    public string ContentTextBox
    {
        get => contentTextBox;
        set
        {
            contentTextBox = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ContentTextBox)));
        }

    }


    private string titleTextBox;

    public string TitleTextBox
    {
        get => titleTextBox;
        set
        {
            titleTextBox = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitleTextBox)));
        }

    }

    private string authorTextBox;

    public string AuthorTextBox
    {
        get => authorTextBox;
        set
        {
            authorTextBox = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthorTextBox)));
        }

    }

    private void BackButton(object sender, RoutedEventArgs e)
    {
        booksWindow.Show();
        Close();
    }

   

    private void Window_Closing(object sender, CancelEventArgs e)
    {
        booksWindow.Show();
    }


}
