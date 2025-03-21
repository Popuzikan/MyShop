﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Customer<R, T> : ICustomer<R>, IEquatable<Customer<R, T>>
    {
        public event EventHandler<CustomerInfoEventArgs<R>> WelcomeCustomer = null;

        public R Name { get; set; }

        public Guid Code { get; set; } = Guid.NewGuid();

        public Carts<T> Cart { get; set; }

        public Customer(R name, Carts<T> cart) => (Name, Cart) = (name, cart);

        public override string ToString() => $"Имя: {Name.ToString()} - код: {Code}";

        public void CustomerEvent(R name) => RaiseNewCustomerInfo(name);
        

        // я этот метод исправлял тебе зачем тут половина? кода
        //protected virtual void RaiseNewCustomerInfo(R name)
        //{
        //    EventHandler<CustomerInfoEventArgs<R>> newCustomerlnfo = WelcomeCustomer;
        //    if (newCustomerlnfo != null)
        //    {
        //        newCustomerlnfo(this, new CustomerInfoEventArgs<R>(name));
        //    }
        //}

        //делать хотябы так
        protected virtual void RaiseNewCustomerInfo(R name) => WelcomeCustomer?.Invoke(this, new CustomerInfoEventArgs<R>(name));
            
        public void Welcome() => CustomerEvent(Name);
        
        // почему тут фор был??????? не понятно этож ведь лишняя индексация
        public void ShowCart()
        {
            foreach (var item in Cart.Cart) // название Cart.Cart не смущает???       
                Console.Write($"{item.ToString()}, ");

            Console.WriteLine();
        }

        public bool Equals(Customer<R, T> other)
        {
            if (other == null)
                return false;

            return Name.ToString() == other.Name.ToString();
        }

        public override bool Equals(object obj) => Equals((Customer<R, T>)obj);

        public override int GetHashCode() => Name.GetHashCode();

        public static bool CompareNames(Customer<R, T> el, Customer<R, T> e2)
        {
            bool help = false;
            if (String.Compare(el.Name.ToString(), e2.Name.ToString()) == -1)
                help = true;
            return help;
        }


    }
}
