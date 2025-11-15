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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Book_Чернышков
{
    
    public partial class MainWindow : Window
        {List<Classes.Author> AllAuthors = Classes.Author.AllAuthors();
        List<Classes.Genre> AllGeners = Classes.Genre.AllGeners();
        List<Classes.Book> AllBooks = Classes.Book.AllBook();
        public MainWindow()
        {
            InitializeComponent();
            AddAuthors();
            AddGenres();
            AddYears();
            CreateUI(AllBooks);
        }

        public void CreateUI(List<Classes.Book> AllBooks)
        {
            parent.Children.Clear();
            foreach (Classes.Book book in AllBooks)
            parent.Children.Add(new Elements.Element(book));
        }

        public void AddAuthors()
        {
            cbAuthors.Items.Add("Выберете ...");
            foreach (Classes.Author Author in AllAuthors)
                cbAuthors.Items.Add(Author.FIO);
        }

        public void AddGenres()
        {
            cbGenres.Items.Add("Выберете ...");
            foreach (Classes.Genre Genre in AllGeners)
                cbGenres.Items.Add(Genre.Name);
        }

        public void AddYears()
        {
            cbYear.Items.Add("Выберете ...");
            List<int> AllYears = new List<int>();    
            foreach (Classes.Book Book in AllBooks)
                if (AllYears.Find(x => x == Book.Year) == 0)
                {
                    AllYears.Add(Book.Year);
                    cbYear.Items.Add(Book.Year);
                }
        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Book(object sender, KeyEventArgs e) => Search();

        private void SelectAuthor(object sender, SelectionChangedEventArgs e) => Search();

        public void Search()
        {
            List<Classes.Book> FindBook = AllBooks.FindAll(x => x.Name.ToLower().Contains(tbSearch.Text.ToLower()));

            if (cbAuthors.SelectedIndex > 0)
            {
                Classes.Author SelectAuthor = AllAuthors.Find(x => x.FIO == cbAuthors.SelectedItem.ToString());
                FindBook = FindBook.FindAll(x => x.Authors.Find(y => y.Id == SelectAuthor.Id) != null);
            }

            if (cbGenres.SelectedIndex > 0)
            {
                Classes.Genre SelectGender = AllGeners.Find(x => x.Name == cbGenres.SelectedItem.ToString());
                FindBook = FindBook.FindAll(x => x.Genres.Find(y => y.Id == SelectGender.Id) != null);
            }

            if (cbYear.SelectedIndex > 0)
                FindBook = FindBook.FindAll(x => x.Year == Convert.ToInt32(cbYear.SelectedItem.ToString()));

            CreateUI(FindBook);
        }
    }
}
