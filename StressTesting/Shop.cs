using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressTesting
{
    public class Shop
    {
        public double Checkout(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}
