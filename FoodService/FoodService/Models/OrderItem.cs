using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodService.Models
{
    public class OrderItem
    {        
        public int Id { get; set; }
        
        [ForeignKey("Order")] 
        public int OrderId { get; set; }

        [ForeignKey("Dish")] 
        public  int DishId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }

    }
}