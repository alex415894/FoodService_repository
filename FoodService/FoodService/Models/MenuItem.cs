using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodService.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
      
        [ForeignKey("Dish")] 
        public virtual int Dish_Id  { get; set; }

        public virtual Dish Dish { get; set; }

        //public IEnumerable<Dish> Dish { get; set; }
        //public virtual ICollection<Dish> Dishes { get; set; }
    }
}