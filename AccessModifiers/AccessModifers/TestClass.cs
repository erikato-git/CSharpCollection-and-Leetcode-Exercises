using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifers
{
    public class TestClass
    {
        public string PublicField = "public";    // Can be accessed by all classes in all assemblies
        internal string InternalField = "internal";     // Can only be accessed by all classes in the same assembly
        protected string ProtectedField = "protected";  // Can only be accessed in its own or derived classes but that counts for all assemblies
        protected internal string ProtectedInternalField = "protectedInternal"; // In the same assembly it works as internal but in another assembly it works as an protected
        private protected string PrivateProtected = "privateProtected"; // Works as an protected but can only be accessed in its own assembly
        private string PrivateField = "private";    // Can only be accessed in its own class, not even derived classes 
    }
}
