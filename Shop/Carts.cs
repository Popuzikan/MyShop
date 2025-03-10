﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    // Alex => зачем он тут?????????
    delegate void MyDelegate<T>(Product<T>[] products);

    public class Carts<T> : ICart<T>
    {
        public Product<T>[] Cart { get; set; }

        public Carts(int size, params Product<T>[] offeredProducts)
        {
            Cart = new Product<T>[size];


            // Alex мне не нравится как ты добавляешь товар для покупателя совсем принципе не пхохо по не вводить его руками, хотябы 1.2.3
            Console.WriteLine($"Введите {size} товаров для покупателя:");

            for (int i = 0; i < size; i++)
            {
                string inPut = Console.ReadLine();
                for (int j = 0; j < offeredProducts.Length; j++)
                     if (inPut as dynamic == offeredProducts[j].Category)
                         Cart[i] = new Product<T>(inPut as dynamic);
            }

            ProductSorter.Sort<T>(Cart, Product<T>.CompareCategory);

        }

    }
}
