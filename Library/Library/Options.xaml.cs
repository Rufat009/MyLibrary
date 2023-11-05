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

namespace Library
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window, INotifyPropertyChanged
    {
        public Options()
        {
            InitializeComponent();
        }


        public List<Book> Books
        {
            get => BookRepo.Show();
           
        }


        private int book;

        public int Book
        {
            get => book ;
            set => PropertyChange(out book, value);

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChange<T>(out T field, T value, [CallerMemberName] string propName = "")
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
