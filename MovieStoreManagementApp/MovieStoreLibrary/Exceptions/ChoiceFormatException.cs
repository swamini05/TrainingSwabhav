using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreLibrary.Exceptions
{
    public class ChoiceFormatException:Exception
    {
        public ChoiceFormatException(string message) : base(message)
        { 
        }  
    }
}
