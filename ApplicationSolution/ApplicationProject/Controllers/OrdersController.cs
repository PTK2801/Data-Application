using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApplicationProject.DAL;
using ApplicationProject.MapConfig;
using ApplicationProject.Models;

namespace ApplicationProject.Controllers
{
    public class OrdersController : Controller
    {
        private WorkContext db = new WorkContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Client);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        
        public ActionResult Create()
        {

            //return View();
            ViewBag.ClientId = db.Clients;
            return PartialView("_PartialViewOrder");
        }



        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationDTO model)
        {


            //try
            //{
            /*
            Order order = new Order {
                OrderId = model.OrderModel.OrderId,
                OrderNumber = model.OrderModel.OrderNumber,
                OrderDate = model.OrderModel.OrderDate,
                Status = model.OrderModel.Status,
                ClientId = model.OrderModel.ClientId,
                Jobs = new Job
                {
                    Title = model.JobModel.Title,
                    Description = model.JobModel.Description,
                    Artworks = new Artwork
                    {
                        Title = model.ArtworkModel.Title,
                        Description = model.ArtworkModel.Description
                    }
                }
            };
            */
            var mapping = MappingConfiguration.InitializeAutoMapper();
            var theOrder = mapping.Map<OrderDTO, Order>(model.OrderModel);

            if (ModelState.IsValid)
            {
                db.Orders.Add(theOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
        //}
                
            //}
           // catch (DataException)
            //{
            /*
                if (!ModelState.IsValid)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log).
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            */
             //}

            

            ViewBag.ClientId = db.Clients;
            return PartialView("_PartialViewOrder", model);
            
        }




        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", order.ClientId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderUpdate = db.Orders.Find(id);
            if (TryUpdateModel(orderUpdate, "", new string[] { "OrderId", "OrderNumber", "OrderDate", "Status", "ClientId" })) {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log).
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", orderUpdate.ClientId);
            return View(orderUpdate);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if problem pesists see your system administrator.";
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log).
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
