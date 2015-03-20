using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("ApplicationUser")] 
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        


    }
}