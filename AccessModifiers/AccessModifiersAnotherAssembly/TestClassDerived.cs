using AccessModifers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiersAnotherAssembly
{
    public class TestClassDerived : TestClass
    {
        public void PrintProtectedMember()
        {
            Console.WriteLine(ProtectedField);
            Console.WriteLine(ProtectedInternalField);
            //Console.WriteLine(PrivateProtected);
            //Console.WriteLine(PrivateField);
        }
    }
}