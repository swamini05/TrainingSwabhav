using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreLibrary.Exceptions
{
    public class DateFormatException:Exception
    {
        public DateFormatException(string message):base(message)
        {
        }
    }
}
