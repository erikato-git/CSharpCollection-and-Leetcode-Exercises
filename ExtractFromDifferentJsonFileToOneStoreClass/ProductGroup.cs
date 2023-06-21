using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractFromDifferentJsonFileToOneStoreClass
{
    public class ProductGroup
    {
        public string Id { get; set; }
        public Group Group { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
