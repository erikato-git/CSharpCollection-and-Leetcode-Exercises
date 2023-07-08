using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_IQueryable
{
    internal class ORM
    {
        public List<Customer> Customers = new List<Customer>(); // 

        public ORM()
        {
            int i = 0;
            Random rnd = new Random();

            while (i < 100)
            {
                Customers.Add(new Customer(rnd.Next(1, 1000)));
                i++;
            }
        }

        public IQueryable<Customer> GetCustomersAsQueryable()
        {
            return Customers.AsQueryable();
        }

        public IEnumerable<Customer> GetCustomersAsEnumerable()
        {
            return Customers.AsEnumerable();
        }
    }
}
