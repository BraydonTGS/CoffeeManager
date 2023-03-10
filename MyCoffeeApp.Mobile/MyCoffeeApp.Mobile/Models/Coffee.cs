using System;

namespace MyCoffeeApp.Mobile.Models
{
   public class Coffee
    {
        public Guid CoffeeId { get; set; }
        public string CoffeeRoaster { get; set; }
        public string CoffeeName { get; set; }    
        public string ImagePath { get; set; }
    }
}
