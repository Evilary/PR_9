using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Чернышков.Classes
{
    public class Book
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Author> Authors { get; set; }

        public int Year { get; set; }

        public Book(int Id, string Name, List<Genre> Genres, List<Author> Authors, int Year)
        {
            this.Id = Id;
            this.Name = Name;
            this.Genres = Genres;
            this.Authors = Authors;
            this.Year = Year;
        }

        public static List<Book> AllBook()
        {
            List<Book> allBook = new List<Book>();


            allBook.Add(new Book(1, "Путешествие в Эвельсин", Genre.AllGeners().FindAll(x => x.Id == 1), Author.AllAuthors().FindAll(x => x.Id == 1), 2023));

            allBook.Add(new Book(2, "Чапаев и пустота", Genre.AllGeners().FindAll(x => x.Id == 1), Author.AllAuthors().FindAll(x => x.Id == 1), 2008));

            allBook.Add(new Book(3, "Дебютная поставка. Том 1", Genre.AllGeners().FindAll(x => x.Id == 2), Author.AllAuthors().FindAll(x => x.Id == 2), 2023));

            allBook.Add(new Book(4, "Дебютная поставка. Том 2", Genre.AllGeners().FindAll(x => x.Id == 2), Author.AllAuthors().FindAll(x => x.Id == 2), 2023));

            allBook.Add(new Book(5, "Охота на попаданку. Бракованная жена", Genre.AllGeners().FindAll(x => x.Id == 2 || x.Id == 3 || x.Id == 4), Author.AllAuthors().FindAll(x => x.Id == 3), 2022));

            return allBook;
        }

        public string ToGenres()
        {
            string toGeners = "";

            for (int iGenre = 0; iGenre < this.Genres.Count; iGenre++)
            {
                toGeners += this.Genres[iGenre].Name;

                if (iGenre < this.Genres.Count - 1)
                    toGeners += ", ";
            }
            return toGeners;
        }

        public string ToAuthors()
        {
            string toAuthors = "";
            for (int iAuthors = 0; iAuthors < this.Authors.Count; iAuthors++)
            {

                toAuthors += this.Authors[iAuthors].FIO;

                if (iAuthors <  this.Authors.Count - 1)
                    toAuthors += ", ";

            }
            return toAuthors;
        }
    }
}
