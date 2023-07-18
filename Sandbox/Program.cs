

using MongoDB.Bson;
using System.Collections;

ArrayList al = new ArrayList();

al.Add("T");
al.Add(2);
al.Add(3.0);

var json = al.ToJson();

Console.WriteLine(json);

Console.ReadKey();  
