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
        string json = JsonSerializer.Serialize(BookRepo.Show());
        File.WriteAllText("Books.json", json);
        Close();
    }

    private void WelcomeButton(object sender, RoutedEventArgs e)
    {
        Options options = new Options(this);
        options.Show();
        Hide();
        
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
        string json = JsonSerializer.Serialize(BookRepo.Show());
        File.WriteAllText("Books.json", json);
    }
}
