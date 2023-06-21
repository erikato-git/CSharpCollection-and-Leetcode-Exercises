
using ExtractFromJsonFile;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

string link = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\ExtractFromJsonFile\Sample.json";

WebRequest request = WebRequest.Create(link);
WebResponse response = request.GetResponse();

using (Stream dataStream = response.GetResponseStream())
{
    StreamReader reader = new StreamReader(dataStream);
    string responseFromServer = reader.ReadToEnd();

    Root root = JsonConvert.DeserializeObject<Root>(responseFromServer);

    foreach (Student item in root.Student)
    {
        Console.WriteLine(item.Name + " " + item.Surname + " " + item.Age);

        for (int i = 0; i < item.Jobs.Count; i++)
        {
            Console.WriteLine(item.Jobs[i]);
        }

        Console.WriteLine();
    }
}






