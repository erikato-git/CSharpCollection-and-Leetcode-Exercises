using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractFromJsonFile
{
    public class Student
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<string> Jobs { get; set; }

    }

    public class Root
    {
        public List<Student> Student { get; set; }
    }

}
