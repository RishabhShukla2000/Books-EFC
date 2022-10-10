using BookWriters.Context;
using BookWriters.Models;
using BookWriters.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookWriters.Controllers
{
    public class BookController : Controller
    { 
     IBookServices iss;
     public BookController(IBookServices _iss)
     {
            iss = _iss;
     }
  
    
        public IActionResult Index()
        {
            return View(iss.GetAllBooks());
        }

        public IActionResult Delete(int ID)
        {
           iss.DeleteBook(ID);
           return RedirectToAction("Index");  
        }
    }
}
