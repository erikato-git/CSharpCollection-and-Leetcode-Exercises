using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Serialization
{
    // using serialization to store objects of this class in a file e.g. XML-file
    [Serializable]
    internal class Animal : ISerializable
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public Animal() { }
      
        public Animal(string name = "No name", double weight = 0, double height = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return string.Format("{0} name, {1} weight, {2} height", Name, Weight, Height);
        }

        // Serialize data
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name",Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
        }

        // Deserialize data
        public Animal(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
        }


    }
}
