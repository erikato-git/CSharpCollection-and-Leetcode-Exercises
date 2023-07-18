using Generics;
using static Generics.Generic;


Generic g = new Generic();

g.GetSum(5,4);
g.GetSum("5", "4");     // same method as above



Rectangle<int> rec1 = new Rectangle<int>(20,50);
Console.WriteLine(rec1.GetArea());

Rectangle<string> rec2 = new Rectangle<string>("20", "50");     // same method as above
Console.WriteLine(rec2.GetArea());


Console.ReadLine();

