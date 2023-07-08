using AccessModifers;

var testClass = new TestClass();

Console.WriteLine(testClass.PublicField);
Console.WriteLine(testClass.InternalField);
//Console.WriteLine(testClass.ProtectedField);
Console.WriteLine(testClass.ProtectedInternalField);
//Console.WriteLine(testClass.PrivateProtected);
//Console.WriteLine(testClass.PrivateField);
