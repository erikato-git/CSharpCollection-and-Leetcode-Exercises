using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    internal class Delegate_Solutions
    {
        delegate void StringDelegate(string text);
        static void ToUpperCase(string text) => Console.WriteLine(text.ToUpper());
        static void ToLowerCase(string text) => Console.WriteLine(text.ToLower());

        public void DelegateMethod() 
        {
            StringDelegate sd = ToUpperCase;
            sd("This is from uppercase function");
            sd = ToLowerCase;
            sd("This is from lowercase function");

        }
    }
}
