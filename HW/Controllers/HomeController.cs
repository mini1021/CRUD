using HW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private bookEntities db = new bookEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult edit(BookList bk)
        {
            ViewBag.bookName = bk.bookName;
            ViewBag.episode = bk.episode;
            if (string.IsNullOrEmpty(bk.bookName) ||
                string.IsNullOrEmpty(bk.episode))
            {
                return View();
            }

            db.BookLists.Add(bk);
            db.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult list()
        {
            
            List<BookList> bk = db.BookLists.ToList<BookList>();
            return View(bk);

        }
        public ActionResult Updata(int? id)
        {

            BookList bk = db.BookLists.Find(id);
            return View(bk);
        }
        [HttpPost]
        public ActionResult Updata(BookList oldbk)
        {
            
            BookList bk = db.BookLists.Find(oldbk.bookId);
            bk.bookName = oldbk.bookName;
            bk.episode = oldbk.episode;
            db.SaveChanges();
            return RedirectToAction("list");
        
        }
        public ActionResult Delete(int? id)
        {

            BookList bk = db.BookLists.Find(id);
            db.BookLists.Remove(bk);
            db.SaveChanges();
            return RedirectToAction("list");
        }
    }
}