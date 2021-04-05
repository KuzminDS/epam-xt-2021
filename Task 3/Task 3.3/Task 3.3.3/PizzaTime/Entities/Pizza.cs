using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.Entities
{
    public class Pizza
    {
        public Pizzas Name { get; private set; }

        public TimeSpan CookingTime { get; private set; }

        public Pizza(Pizzas name, int minutes)
        {
            Name = name;
            CookingTime = new TimeSpan(0, 0, minutes); // Для ускорения процесса
        }
    }
}
