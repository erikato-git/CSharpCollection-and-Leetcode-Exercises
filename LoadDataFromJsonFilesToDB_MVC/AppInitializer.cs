using System.Net;
using LoadDataFromJsonFilesToDB_MVC.Models;
using Newtonsoft.Json;

namespace LoadDataFromJsonFilesToDB_MVC
{
    public class AppInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureCreated();

                // Group
                if(!context.Groups.Any())
                {
                    string link = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\LoadDataFromJsonFilesToDB_MVC\Data\Groups.json";

                    WebRequest request = WebRequest.Create(link);
                    WebResponse response = request.GetResponse();

                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();

                        RootG root = JsonConvert.DeserializeObject<RootG>(responseFromServer);

                        foreach (Group item in root.Groups)
                        {
                            item.CreationDate = DateTime.Now;
                            context.Groups.Add(item);
                        }
                    }

                    context.SaveChanges();

                }

                // Product
                if (!context.Products.Any())
                {
                    string link = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\LoadDataFromJsonFilesToDB_MVC\Data\Products.json";

                    WebRequest request = WebRequest.Create(link);
                    WebResponse response = request.GetResponse();

                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string responseFromServer = reader.ReadToEnd();

                        RootP root = JsonConvert.DeserializeObject<RootP>(responseFromServer);

                        foreach (Product item in root.Products)
                        {
                            item.CreationDate = DateTime.Now;
                            context.Products.Add(item); 
                        }
                    }

                    context.SaveChanges();
                }


                // Price
                if (!context.Prices.Any())
                {
                    string filePath = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\LoadDataFromJsonFilesToDB_MVC\Data\Prices.csv";

                    try
                    {
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            string line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                var price = new PriceModel();
                                string[] rowData = line.Split(' ');
                                price.ProductNumber = rowData[0].Trim();
                                price.Price = -1;
                                price.CreationDate = DateTime.UtcNow;

                                context.Prices.Add(price);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
