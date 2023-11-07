﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
    public partial class Options : Window, INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        MainWindow mainWindow;

        public Options(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            DataContext = this;

            foreach (Book item in BookRepo.Show()) {
                Books.Add(item);
            }

        }

        private ObservableCollection<Book> books = new ObservableCollection<Book>();

        public ObservableCollection<Book> Books {
            get { return books; }
            set { books = value; }
        }


        private Book book;

        public Book Book
        {
            get => book;
            set
            {
                book = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Book)));
            }

        }

        private int bookIndex;

        public int BookIndex {
            get => bookIndex;
            set {
                bookIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BookIndex)));
            }

        }


        private string searchText;

        public string SearchText {
            get => searchText;
            set {
                searchText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));
            }

        }


        private void Window_Closing(object sender, CancelEventArgs e) {
            mainWindow.Show();
        }

        private void AddButton(object sender, RoutedEventArgs e) {
            new AddBook(this, Books).Show();
            Hide();
        }

        private void EditButton(object sender, RoutedEventArgs e) {
            new EditBook(this, Books, BookIndex,Book).Show();
            Hide();
        }

        private void DeleteButton(object sender, RoutedEventArgs e) {
            if (Book != null) {
                BookRepo.Delete(Book);
                Books.Clear();
                foreach (Book item in BookRepo.Show()) {
                    Books.Add(item);
                }
            }
        }

        private void SearchButton(object sender, RoutedEventArgs e) {

            if (SearchText == null) {
                return;
            }

            if (SearchText == "") {
                Books.Clear();
                foreach (Book item in BookRepo.Show()) {
                    Books.Add(item);
                }
            }
            else {
                Books.Clear();
                foreach (Book item in BookRepo.Search(SearchText)) {
                    Books.Add(item);
                }
            }
        }
    }
}
