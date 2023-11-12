using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }

    private void ExitButton(object sender, RoutedEventArgs e)
    {
        string json = JsonSerializer.Serialize(BookRepository.Show());
        Console.WriteLine(json);
        File.WriteAllText("../../../Books.json", json);
        Close();
    }

    private void WelcomeButton(object sender, RoutedEventArgs e)
    {
        BooksWindow options = new BooksWindow(this);
        options.Show();
        Hide();
        
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
        string json = JsonSerializer.Serialize(BookRepository.Show());
        File.WriteAllText("../../../Books.json", json);
    }
}
