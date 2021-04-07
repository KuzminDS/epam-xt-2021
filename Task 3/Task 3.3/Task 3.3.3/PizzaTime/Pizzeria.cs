using PizzaTime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime
{
    public class Pizzeria
    {
        private List<Pizza> _pizzasList;
        private List<Order> _ordersList;

        public IReadOnlyList<Pizza> Pizzas => _pizzasList.AsReadOnly();
        public IReadOnlyList<Order> Orders => _ordersList.AsReadOnly();

        public event Action<object, Order> OnOrderAcceptance;
        public event Action<object, Order> OnCooked;

        public Pizzeria(List<Pizza> pizzas)
        {
            _pizzasList = new List<Pizza>(pizzas);
            _ordersList = new List<Order>();
        }

        public async Task MakeOrder(Pizzas pizzaName)
        {
            var pizza = _pizzasList.Find(p => p.Name == pizzaName);

            if (pizza == null)
                throw new Exception($"Пиццы {pizzaName} не существует");

            var order = new Order(_ordersList.Count + 1, pizza);

            _ordersList.Add(order);
            OnOrderAcceptance?.Invoke(this, order);

            await Cook(order);
        }

        private async Task Cook(Order order)
        {
            await Task.Delay(order.Pizza.CookingTime); // приготовление пиццы

            OnCooked?.Invoke(this, order);
            _ordersList.Remove(order);
        }
    }
}
