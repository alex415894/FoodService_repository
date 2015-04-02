using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodService.Models;

namespace FoodService.Controllers.api
{
    public class MenuItemsController : ApiController
    {   
        //Get list for date
        //Add
        //Remove
         

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MenuItems
        public IQueryable<MenuItem> GetListForDate(DateTime date)
        {
            return db.MenuItems
                .Where(p => p.Date == date); 
        }

        // GET: api/MenuItems/5
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult GetMenuItem(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        // PUT: api/MenuItems/5
        [ResponseType(typeof(void))]
         public IHttpActionResult PutMenuItem(int id, MenuItem menuItem)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }

             if (id != menuItem.Id)
             {
                 return BadRequest();
             }

             db.Entry(menuItem).State = EntityState.Modified;

             try
             {
                 db.SaveChanges();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!MenuItemExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return StatusCode(HttpStatusCode.NoContent);
         } 

        // POST: api/MenuItems
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult PostMenuItem(int id, int dish_Id, DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuItems.Add(new MenuItem { Id = id, Date = date, Dish_Id = dish_Id });
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = id }, new { id = id, date = date, dish_Id = dish_Id });
        }

        // DELETE: api/MenuItems/5
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult DeleteMenuItem(int id)
        {
            MenuItem menuItem = db.MenuItems.Find(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            db.MenuItems.Remove(menuItem);
            db.SaveChanges();

            return Ok(menuItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuItemExists(int id)
        {
            return db.MenuItems.Count(e => e.Id == id) > 0;
        }
    }
}