using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Services
{
    public class LibraryService
    {
        private static ICollection<Books> books;

        public LibraryService()
        {
            books = new List<Books>(); 
        }

        public IEnumerable<Books> GetBooks()
        {
            return books.ToList();
        }

        public Books GetBook(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public Books BookSearch(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }

        public void AddBook(Books book)
        {
            book.Id = GetId();
            books.Add(book);
        }

        

        public int GetId()
        {
            Books book = books.LastOrDefault();
            if(book != null)
            {
                return book.Id + 1;
            }return 1;
        }
    }
}
