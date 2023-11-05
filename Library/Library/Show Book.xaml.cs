using System;
using System.Collections.Generic;
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
/// Interaction logic for Show_Book.xaml
/// </summary>
public partial class Show_Book : Window
{
    public Show_Book()
    {
        InitializeComponent();
    }
    private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
    {
        // Создание экземпляра нового окна
        Show_Book newWindow = new Show_Book();

        // Открытие нового окна
        newWindow.Show();
    }



}
