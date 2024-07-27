﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreLibrary.Exceptions
{
    public class MovieStoreCapacityFullException:Exception
    {
        public MovieStoreCapacityFullException(string message) : base(message)
        {
        }
    }
}
