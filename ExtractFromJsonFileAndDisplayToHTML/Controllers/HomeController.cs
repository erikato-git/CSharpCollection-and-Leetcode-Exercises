using ExtractFromJsonFile;
using ExtractFromJsonFileAndDisplayToHTML.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace ExtractFromJsonFileAndDisplayToHTML.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string link = @"C:\Users\erikk\Desktop\Easy_Collection\Easy_Collection\ExtractFromJsonFile\Sample.json";

            WebRequest request = WebRequest.Create(link);
            WebResponse response = request.GetResponse();

            List<Student> Students = new List<Student>();
            var root = new Root();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                root = JsonConvert.DeserializeObject<Root>(responseFromServer);

                foreach (Student item in root.Student)
                {
                    Console.WriteLine(item.Name + " " + item.Surname + " " + item.Age);

                    for (int i = 0; i < item.Jobs.Count; i++)
                    {
                        Console.WriteLine(item.Jobs[i]);
                    }

                    Console.WriteLine();

                    Students.Add(item);
                }
            }

            return View(root.Student);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}