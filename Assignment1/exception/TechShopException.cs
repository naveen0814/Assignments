using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace TechShop.exception
{
    public class TechShopException : Exception
    {
        public TechShopException(string message) : base(message) { }
    }
}