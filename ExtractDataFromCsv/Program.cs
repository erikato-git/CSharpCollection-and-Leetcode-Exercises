
using System.IO;
using System.Net;

string filePath = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\ExtractDataFromCsv\Prices.csv";


try
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}











