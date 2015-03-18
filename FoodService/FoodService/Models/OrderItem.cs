using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodService.Models
{
    public class OrderItem
    {        
        public int Id { get; set; }
        public int OrderId { get; set; }
        public  int DishId { get; set; }

        public  Dish Dish { get; set; }
        public Order Order { get; set; }

    }
}