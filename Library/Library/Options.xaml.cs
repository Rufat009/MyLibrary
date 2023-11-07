using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window, INotifyPropertyChanged
    {
        MainWindow mainWindow;

        public Options(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = this;
        }

        private List<Book> books;
        public List<Book> Books
        {
            get => BookRepo.Show();
            set
            {
                books = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
            }

        }


        private int book;

        public int Book
        {
            get => book ;
            set
            {
                book = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Book)));
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;

       

        private void Window_Closing(object sender, CancelEventArgs e) {
            mainWindow.Show();
        }

        private void AddButton(object sender, RoutedEventArgs e) {
            new AddBook(this).Show();
            Hide();
        }
    }
}
