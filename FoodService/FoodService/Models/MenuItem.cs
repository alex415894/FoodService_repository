using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodService.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}