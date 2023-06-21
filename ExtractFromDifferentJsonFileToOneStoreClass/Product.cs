using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractFromDifferentJsonFileToOneStoreClass
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Product
    {
        public string Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }

    public class RootP
    {
        public List<Product> Products { get; set; }
    }


}
