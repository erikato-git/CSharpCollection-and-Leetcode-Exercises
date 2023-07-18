using Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


Animal bowser = new Animal("Bowser", 45, 22);

Stream stream = File.Open("Animal.dat", FileMode.Create);

BinaryFormatter bf = new BinaryFormatter();

bf.Serialize(stream, bowser);   





Console.ReadLine();






