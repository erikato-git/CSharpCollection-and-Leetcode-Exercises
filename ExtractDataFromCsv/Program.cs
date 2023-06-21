
using System.Diagnostics;
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
            string[] rowData = line.Split(' ');
            Console.WriteLine(rowData[0].Trim());
            Console.WriteLine(rowData[1].Trim());   // Kan ikke splitte de to kolonner!!!

            //Console.WriteLine(line);
        }
    }

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}











