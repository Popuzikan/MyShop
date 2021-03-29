using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Carts<T> : ICart<T>
    {
        public Product<T>[] Cart { get; set; }

        public Carts(int size, params Product<T>[] offeredProducts)
        {
            Cart = new Product<T>[size];

            Console.WriteLine($"Введите {size} номера товаров для покупателя:");

            for (int i = 0; i < size; i++)
            {
                try {
                    int inPut = int.Parse(Console.ReadLine());

                    //for (int j = 0; j < offeredProducts.Length; j++) // в таком ключе тебе Length может выкинуть nullofrefrences exaptions
                    //{
                    //    if (inPut == j+1)
                    //        Cart[i] = new Product<T>(offeredProducts[j].Category);
                    //}
                    //тут не нравится мне испоьзуй форич ни коких фор в форе и подумай что тут просиходет ты как бы создаешь новый продукт и из имеющихся продукто в продукты суешь продукт 
                    //не забывай про ()?: не используешь
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }


            // зачем это тут??? не понимаю слишком замудренно дай возможность работы делегатам для сортировки или метод добавь новый либо лелегат в параметр метода который примет твой метод 
            // так не делается это хардкод 
            ProductSorter.Sort<T>(Cart, Product<T>.CompareCategory);

        }

    }
}
