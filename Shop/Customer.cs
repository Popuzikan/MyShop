﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Customer<R, T> : ICustomer<R>, IEquatable<Customer<R, T>>
    {
        public R Name { get; set; }

        public Guid Code { get; set; } = Guid.NewGuid();

        public Carts<T> Cart { get; set; }

        public Customer(R name, Carts<T> cart) => (Name, Cart) = (name,cart); // Синтаксический сахар с .Net 8.0 касается только инициализации поэтому по defaule Guid
       
        public override string ToString() => $"Имя: {Name.ToString()} - код: {Code}";

        public void ShowCart()
        {
            for (int i = 0; i < Cart.Cart.Length; i++)
                Console.Write($"{ Cart.Cart[i].ToString()}, ");

            Console.WriteLine();
        }

        public bool Equals(Customer<R, T> other) // Метод икулэлс
        {
            if (other == null)
                return false;

            return Name.ToString() == other.Name.ToString();
        }

        public override bool Equals(object obj) => Equals((Customer<R, T>)obj);

        public override int GetHashCode() => Name.GetHashCode();

        public static bool CompareNames(Customer<R, T> el, Customer<R, T> e2) // Alex=> что за e2?????
        {
            bool help = false;
            if (string.Compare(el.Name.ToString(), e2.Name.ToString()) == -1)
                help = true;
            return help;
        }


    }
}
