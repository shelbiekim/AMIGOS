using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Amigos.Models;

namespace Amigos.Controllers
{
    public class BooksController : Controller
    {
        private Database1Entities1 db = new Database1Entities1();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Image).Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        //[HandleError(View = "BadRequest", ExceptionType = typeof(HttpRequestValidationException))]
        
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName");
            ViewBag.ImageId = new SelectList(db.Images, "Id", "ImageTitle");
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "PublisherName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,TotalPages,ISBN,PublishedDate,AuthorId,PublisherId,ImageId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();

                ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
                ViewBag.ImageId = new SelectList(db.Images, "Id", "ImageTitle", book.ImageId);
                ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "PublisherName", book.PublisherId);
                return RedirectToAction("Index");

            }
            else { 
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.ImageId = new SelectList(db.Images, "Id", "ImageTitle", book.ImageId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "PublisherName", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,TotalPages,ISBN,PublishedDate,AuthorId,PublisherId,ImageId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "AuthorName", book.AuthorId);
            ViewBag.ImageId = new SelectList(db.Images, "Id", "ImageTitle", book.ImageId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "Id", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
