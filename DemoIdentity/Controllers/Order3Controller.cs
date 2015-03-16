using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoIdentity.Models;
//Adding new field to use Identity
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
namespace DemoIdentity.Controllers
{
    [Authorize]
    public class Order3Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order3
        public async Task<ActionResult> Index()
        {
            var orders = db.Orders.Include(o => o.User);

             var manager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(
                        new ApplicationDbContext()
                        )
                    );
            var user = manager.FindById(User.Identity.GetUserId());

            return View(await orders.Where(o=>o.UserID == user.Id ) .ToListAsync());
        }

        // GET: Order3/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order3/Create
        public ActionResult Create()
        {
               var manager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(
                        new ApplicationDbContext()
                        )
                    );
            var user = manager.FindById(User.Identity.GetUserId());            
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username");
            ViewBag.MyUserID = user.Id;
            return View();
        }

        // POST: Order3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,UserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.UserID = new SelectList(db.ApplicationUsers, "Id", "Firstname", order.UserID);
            return View(order);
        }

        // GET: Order3/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", order.UserID);
     //       var manager = new UserManager<ApplicationUser>(
     //new UserStore<ApplicationUser>(
     //    new ApplicationDbContext()
     //    )
     //);
     //       var user = manager.FindById(User.Identity.GetUserId());
            //ViewBag.MyUserID = user.Id;
            //ViewBag.UserID = user.Id;
            return View(order);
        }

        // POST: Order3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,UserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", order.UserID);
     //       var manager = new UserManager<ApplicationUser>(
     //new UserStore<ApplicationUser>(
     //    new ApplicationDbContext()
     //    )
     //);
     //       var user = manager.FindById(User.Identity.GetUserId());
     //       //ViewBag.MyUserID = user.Id;
     //       ViewBag.UserID = user.Id;
            return View(order);
        }

        // GET: Order3/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
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
