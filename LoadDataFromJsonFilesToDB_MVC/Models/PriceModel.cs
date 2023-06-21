using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataFromJsonFilesToDB_MVC
{
    public class PriceModel
    {
        [Key]
        public string ProductNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
