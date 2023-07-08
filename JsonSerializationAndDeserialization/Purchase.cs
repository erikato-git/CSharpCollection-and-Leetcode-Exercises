using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializationAndDeserialization
{
    internal class Purchase
    {
        public string? ProductName { get; set; }
        public DateTime DateTime { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
