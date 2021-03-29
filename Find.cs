using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Find
    {
        public static void TryGetCartOrder<R>(IDictionary<R, Customer<string, string>> orderRepository, R code)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Результаты поиска:");
            if (code != null)
                if (orderRepository.TryGetValue(code, out Customer<string, string> customer)) // а если не будет такого клиента что вернет метод в out и что будет на customer.ShowCart(); ниже?

                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    Console.WriteLine($"{code.ToString()}:{customer.ToString()}");
                    customer.ShowCart();
                }
                else
                    Console.WriteLine("Данного покупателя нет в скписке.");
        }
    }
}
