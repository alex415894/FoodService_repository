using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodService.Models
{
    public interface IDishRepository : IDisposable
    {
        IEnumerable<Dish> GetDishList();
        Dish GetDish(int id);
        void Add(Dish dish);
        void Update(Dish dish);
        void Delete(int id);
        void Save();
        bool DishExists(int id);
    }
    
    public class DishRepository : IDishRepository // :IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Dish> GetDishList()
        {
            return db.Dishes;
        }
        public Dish GetDish(int id)
        {
            return db.Dishes.Find(id);                   //FirstOrDefault(p => p.Id == id);
        }
        public void Add(Dish dish)
        {
            db.Dishes.Add(dish);
            db.SaveChanges();
        }

        public void Update(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public bool DishExists(int id)
        {
            return db.Dishes.Count(e => e.Id == id) > 0;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
        
    }
}