using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelProj.Exceptions
{
    public class PageException :Exception
    {
        public PageException(string message) : base(message)
        { }
    }
}
