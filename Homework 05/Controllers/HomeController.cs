using Homework_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework_05.Controllers
{
    public class HomeController : Controller
    {

        private DataServices dataService = DataServices.getInstance();

        public ActionResult Index()
        {
            return View();
        }




        public ActionResult ViewBooks2(string SearchString, string AuthSelect, string TypeSelect)
        {
            AuthSelect = (AuthSelect == null) ? "" : AuthSelect;
            SearchString = (SearchString == null) ? "" : SearchString;
            TypeSelect = (TypeSelect == null) ? "" : TypeSelect;

            List < BooksVM > booksVM = dataService.getAllBooks();
            
            AuthSelect = String.Compare(AuthSelect, "Select an Author") == 0 ? "" : AuthSelect;
            TypeSelect = String.Compare(TypeSelect, "Select a Type") == 0 ? "" : TypeSelect;

            ViewData["CurrentFilter"] = SearchString;
            ViewData["AuthFilter"] = AuthSelect;
            ViewData["TypeFilter"] = TypeSelect;

            var query = from l in booksVM
                       select l;

            query = query.Where(l => l.author.Surname.Contains(AuthSelect) && l.book.Name.Contains(SearchString) && l.type.Name.Contains(TypeSelect));           
            
            return View(query.ToList());
            
        }



        public ActionResult ViewDetails(int borID, string bookName)
        {
            List<BorrowsVM> borrowsVMs = dataService.getAllBorrows(borID);
            ViewBag.Message = bookName;
            return View(borrowsVMs);
        }





        public ActionResult ShowStudents(string TextString, string ClassSelect)
        {
            TextString = (TextString == null) ? "" : TextString;
            ClassSelect = (ClassSelect == null) ? "" : ClassSelect;

            List<Students> studentlist = dataService.getAllStudents();

            ClassSelect = String.Compare(ClassSelect, "Select a Class") == 0 ? "" : ClassSelect;

            ViewData["NewFilter"] = TextString;
            ViewData["ClassFilter"] = ClassSelect;

            var query1 = from l in studentlist
                        select l;

            query1 = query1.Where(l => l.Name.Contains(TextString) && l.Class.Contains(ClassSelect));

            return View(query1.ToList());
        }
    }
}