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
    public class MenuItemController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MenuItem
        public IQueryable<MenuItem> GetMenuItems()
        {
            return db.MenuItem;
        }

        // GET: api/MenuItem/5
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult GetMenuItem(int id)
        {
            MenuItem menuItem = db.MenuItem.Find(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        // PUT: api/MenuItem/5
 
  /*      [ResponseType(typeof(void))]
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
*/
        // POST: api/MenuItem
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult PostMenuItem(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuItem.Add(menuItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = menuItem.Id }, menuItem);
        }

        // DELETE: api/MenuItem/5
        [ResponseType(typeof(MenuItem))]
        public IHttpActionResult DeleteMenuItem(int id)
        {
            MenuItem menuItem = db.MenuItem.Find(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            db.MenuItem.Remove(menuItem);
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
            return db.MenuItem.Count(e => e.Id == id) > 0;
        }
    }
}