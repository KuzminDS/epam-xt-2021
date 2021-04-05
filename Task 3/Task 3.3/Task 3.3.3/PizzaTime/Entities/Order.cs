using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.Entities
{
    public class Order
    {
        public int Number { get; private set; }

        public Pizza Pizza { get; private set; }

        public Order(int number, Pizza pizza)
        {
            Number = number;
            Pizza = pizza;
        }
    }
}
