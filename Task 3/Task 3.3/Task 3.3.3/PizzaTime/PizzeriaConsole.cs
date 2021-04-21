using PizzaTime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime
{
    public class PizzeriaConsole
    {
        private Pizzeria _pizzeria;

        public PizzeriaConsole()
        {
            var pizzaList = new List<Pizza>();
            pizzaList.Add(new Pizza(Pizzas.Buffalo, 5));
            pizzaList.Add(new Pizza(Pizzas.Cheese, 6));
            pizzaList.Add(new Pizza(Pizzas.Margherita, 7));
            pizzaList.Add(new Pizza(Pizzas.Pepperoni, 5));
            pizzaList.Add(new Pizza(Pizzas.Chicken, 8));

            _pizzeria = new Pizzeria(pizzaList);

            _pizzeria.OnOrderAcceptance += Console_OnOrderAcceptance;
            _pizzeria.OnCooked += Console_OnCooked;
        }

        public void Start()
        {
            do
            {
                PrintMenu();
                var value = Console.ReadLine();
                if (!int.TryParse(value, out int option) || option <= 0 || option > _pizzeria.Pizzas.Count)
                    break;

                _pizzeria.MakeOrder(_pizzeria.Pizzas[option - 1].Name);

            } while (true);
        }

        private void Console_OnOrderAcceptance(object sender, Order order)
        {
            Console.WriteLine($"Заказ {order.Number} - {order.Pizza.Name} принят. Ожидайте приготовления пиццы.");
        }

        private void Console_OnCooked(object sender, Order order)
        {
            Console.WriteLine($"Заказ {order.Number} - {order.Pizza.Name} готов. Можете забрать пиццу.");
        }

        private void PrintMenu()
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                "Сделайте ваш заказ",
                "Выберите пиццу или введите любой другой текст для выхода:"));

            for (int i = 0; i < _pizzeria.Pizzas.Count; i++)
                Console.WriteLine($"{i + 1}. {_pizzeria.Pizzas[i].Name}");
        }
    }
}
