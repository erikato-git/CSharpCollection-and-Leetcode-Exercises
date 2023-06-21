using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadDataFromJsonFilesToDB_MVC
{
    public class Group
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class RootG
    {
        public List<Group> Groups { get; set; }
    }
}
