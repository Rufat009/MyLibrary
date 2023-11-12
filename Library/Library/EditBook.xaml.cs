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
/// Interaction logic for EditBook.xaml
/// </summary>
public partial class EditBook : Window, INotifyPropertyChanged {

    public event PropertyChangedEventHandler? PropertyChanged;
    BooksWindow optionsWindow;
    ObservableCollection<Book> Books;
    
    int index;

    public EditBook(BooksWindow optionsWindow, ObservableCollection<Book> Books, int index, Book book) {
        InitializeComponent();

        this.optionsWindow = optionsWindow;
        this.Books = Books;
        TitleTextBox = book.Title;
        AuthorTextBox = book.Author;
        this.index = index;
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

    public string TitleTextBox {
        get => titleTextBox;
        set {
            titleTextBox = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitleTextBox)));
        }

    }

    private string authorTextBox;

    public string AuthorTextBox {
        get => authorTextBox;
        set {
            authorTextBox = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthorTextBox)));
        }

    }

    private void BackButton(object sender, RoutedEventArgs e) {
        optionsWindow.Show();
        Close();
    }

    private void EditButton(object sender, RoutedEventArgs e) {
        if (!string.IsNullOrWhiteSpace(TitleTextBox) && !string.IsNullOrWhiteSpace(AuthorTextBox) && !string.IsNullOrWhiteSpace(ContentTextBox)) {
            BookRepository.Edit(index, new Book(TitleTextBox, AuthorTextBox, ContentTextBox));
            Books.Clear();
            foreach (Book item in BookRepository.Show()) {
                Books.Add(item);

            }
        }
        optionsWindow.Show();
        Close();
    }

    private void Window_Closing(object sender, CancelEventArgs e) {
        optionsWindow.Show();
    }

    
}


