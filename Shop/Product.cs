using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product<T> : IProduct<T>, IEquatable<Product<T>>
    {
        public T Category { get; set; }

        public Product(T category) => Category = category; //Alex => запоминай: Первое что сетишь второе какой параметр из конструктора .Net 8.0
  
        public override string ToString() => $"{Category.ToString()}";

        public bool Equals(Product<T> other) => (other == null)? false :Category.ToString().Equals(other?.Category.ToString()); //Alex => так лучше

        //public bool Equals(Product<T> other)
        //{
        //    //if (other == null)
        //    //    return false;

        //    return Category.ToString() == (other.Category.ToString()); //Alex => есть же equals!!!!!!!! зачем == ??? и зачем if()
        //}

        public override bool Equals(object obj) => Equals((Product<T>)obj);

        public override int GetHashCode() => Category.GetHashCode();

        //public static bool CompareCategory(Product<T> p1, Product<T> p2) // Alex => ни стеримсь исползовать 1,2,3, используй слова 
        //{
        //    bool help = false;
        //    if (string.Compare(p1.Category.ToString(), p2.Category.ToString()) == -1)
        //        help = true;
        //    return help;
        //}

        // Alex => забываешь про тернарный оператор 
        public static bool CompareCategory(Product<T> first, Product<T> second) => (string.Compare(first.Category.ToString(), second.Category.ToString()) == -1) ? true : false;
    }
}
