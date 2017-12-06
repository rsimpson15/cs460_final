using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using final.Models;

namespace final.Controllers
{
    public class BidsController : Controller
    {
        private Auction db = new Auction();

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidID,BuyerID,ItemID,Price,TimeStamp,Done")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.TimeStamp = DateTime.Now;

                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name", bid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", bid.ItemID);
            return View(bid);
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
