using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataFromJsonFilesToDB
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }

    //public class RootP
    //{
    //    public List<Product> Products { get; set; }
    //}
}
