using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Чернышков.Classes
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int Id, string Name) {
            this.Id = Id;
            this.Name = Name;

        }
        public static List<Genre> AllGeners()
        {
            List<Genre> allGeners = new List<Genre>();

            allGeners.Add(new Genre(1, "Современная русская литература"));
            allGeners.Add(new Genre(2, "Современные детективы"));
            allGeners.Add(new Genre(3, "Любовное фентези"));
            allGeners.Add(new Genre(4, "Попаданцы"));
            allGeners.Add(new Genre(5, "Юмористическое фентези"));

            return allGeners;
        } 
        
        
    }
}
