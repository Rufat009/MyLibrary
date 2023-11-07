using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
/// Interaction logic for AddBook.xaml
/// </summary>
public partial class AddBook : Window, INotifyPropertyChanged {
    public event PropertyChangedEventHandler? PropertyChanged;
    Options optionsWindow;

    public AddBook(Options optionsWindow) {
        InitializeComponent();

        this.optionsWindow = optionsWindow;

        DataContext = this;
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

    private void AddButton(object sender, RoutedEventArgs e) {
        Console.WriteLine(TitleTextBox);
        if (!string.IsNullOrWhiteSpace(TitleTextBox) && !string.IsNullOrWhiteSpace(AuthorTextBox)) {
            BookRepo.Add(TitleTextBox, AuthorTextBox);
        }
        optionsWindow.Show();
        Close();
    }

    private void Window_Closing(object sender, CancelEventArgs e) {
        optionsWindow.Show();
    }
}