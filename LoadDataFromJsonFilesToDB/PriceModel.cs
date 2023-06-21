using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataFromJsonFilesToDB
{
    public class PriceModel
    {
        [Key]
        public string ProductNumber { get; set; }
        public double Price { get; set; }

    }
}
