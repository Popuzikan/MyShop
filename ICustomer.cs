﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    interface ICustomer<R>
    {
        R Name { get; set; }
    }
}
