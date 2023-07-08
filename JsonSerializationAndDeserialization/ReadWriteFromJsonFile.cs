using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonSerializationAndDeserialization
{
    internal class ReadWriteFromJsonFile
    {
        public void Write()
        {
            Purchase purchase = new Purchase
            {
                ProductName = "Orange juice",
                DateTime = DateTime.Now,
                ProductPrice = 2.49m
            };

            var options = new JsonSerializerOptions();
            options.WriteIndented = true;   // pretty printed using text-visualiser

            string jsonString = JsonSerializer.Serialize<Purchase>(purchase, options);     // JSON-visualizer
                                                                                           //byte[] jsonString = JsonSerializer.SerializeToUtf8Bytes(purchase);      // IEnumerable

            File.WriteAllText("purchase.json", jsonString);     // purchase.json can be found at /bin/Debug/net7.0/purchase.json

            Console.WriteLine(jsonString);
        }

        public void Read()
        {
            var purchaseJson = File.ReadAllText("purchase.json");

            Purchase purchase = JsonSerializer.Deserialize<Purchase>(purchaseJson);     // Extract the Json to a Purchase-object

            Console.WriteLine(purchase);
        }
    }
}
