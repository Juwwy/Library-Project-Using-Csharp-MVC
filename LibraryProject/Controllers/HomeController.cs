using LibraryProject.Models;
using LibraryProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryService libraryService;

        public HomeController(LibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Books());
        }

        [HttpPost]
        public IActionResult Add(Books book)
        {
            Books bookInfo = new Books
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Author = book.Author,
                ImgUrl = book.ImgUrl,
                Edition = book.Edition,
                Publisher = book.Publisher
            };
            libraryService.AddBook(book);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult SearchBook()
        {
            return View(new Books());
        }

        public IActionResult DisplayBook(Books book)
        {
            string GetBook = book.Title;
            var output = libraryService.BookSearch(GetBook);
            return View(output);
        }
        public IActionResult Books()
        {
            IEnumerable<Books> book = libraryService.GetBooks();
            return View(book);
        }

        public IActionResult Book(int id)
        {
            Books bookInfo = libraryService.GetBook(id);
            return View(bookInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
