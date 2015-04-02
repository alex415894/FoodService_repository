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
    public class DishesController : ApiController
    {
        private IDishRepository _repository;

        public DishesController(IDishRepository repository)  
        {
        _repository = repository;
        }
        //DishRepository _repository = new DishRepository();

        public IEnumerable<Dish> Get()
        {
            return _repository.GetDishList();
        }
      
        // GET: api/Dishes/5
        [ResponseType(typeof(Dish))]
        public IHttpActionResult GetDish(int id)
        {
            Dish dish = _repository.GetDish(id);
            if (dish == null)
            {
                return NotFound();
            }

            return Ok(dish);
        }

        // PUT: api/Dishes/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "admin")]
        public IHttpActionResult PutDish(int id, Dish dish)
        {
            if (!ModelState.IsValid) {return BadRequest(ModelState);}
            if (id != dish.Id)       {return BadRequest();          }

            _repository.Update(dish);

            try
            {
                _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id)) { return NotFound();}
                else                 { throw;            }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Dishes
        [ResponseType(typeof(Dish))]
        [Authorize(Roles = "admin")]
        public IHttpActionResult PostDish(Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(dish);
            _repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = dish.Id }, dish);
        }

        // DELETE: api/Dishes/5
        [ResponseType(typeof(Dish))]
        [Authorize(Roles = "admin")]
        public IHttpActionResult DeleteDish(int id)
        {
            _repository.Delete(id);
            _repository.Save();

            return Ok();
        }
        

        private bool DishExists(int id)
        {
            return _repository.GetDishList().Count(e => e.Id == id) > 0;
        }
    }
}