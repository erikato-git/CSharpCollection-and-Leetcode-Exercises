using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractFromDifferentJsonFileToOneStoreClass
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class RootG
    {
        public List<Group> Groups { get; set; }
    }
}
