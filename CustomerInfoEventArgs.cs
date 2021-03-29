using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class CustomerInfoEventArgs<R> : EventArgs
    {
        // повторяюсь не копируй код ну и для чего ТУТ this? вы пишите????? 
        //public CustomerInfoEventArgs(R name)
        //{
        //    this.Name = name;
        //}

        public CustomerInfoEventArgs(R name) => Name = name; // показал как надо же почему не юзаешь???

        public R Name { get; private set; }
    }
}
