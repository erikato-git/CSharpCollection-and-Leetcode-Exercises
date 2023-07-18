using IEnumerable_ICollection_IList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1;

namespace IEnumerable_ICollection_IList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // If I wanna work with data stored InMemory I would choose IEnumerable, if I wanna extract data once I would choose IQueryable 

            IEnumerable<Todo> Todo_IE = _context.Todos;
            ICollection<Todo> Todo_IC = _context.Todos.ToList();
            IList<Todo> Todo_IL = _context.Todos.ToList();

            // Iteration - All

            foreach (Todo item in Todo_IE)
            {
                _logger.Log(LogLevel.Information, "IEnumerable - " + item.Item);
            }

            foreach (Todo item in Todo_IC)
            {
                _logger.Log(LogLevel.Information, "ICollection - " + item.Item);
            }

            foreach (Todo item in Todo_IL)
            {
                _logger.Log(LogLevel.Information, "IList - " + item.Item);
            }

            // Sorting - All

            var sortedEnumerable = Todo_IE.Where(u => u.Item.Contains("c")).OrderBy(x => x.Id);
            var sortedCollection = Todo_IC.Where(u => u.Item.Contains("c")).OrderBy(x => x.Id);
            var sortedList = Todo_IL.Where(u => u.Item.Contains("c")).OrderBy(x => x.Id);


            // Adding and Removing - IList & ICollection

            Todo todo_new = new() { Id = 6, Item = "Hundej" };

            Todo_IC.Add(todo_new);
            Todo_IC.Remove(todo_new);

            Todo_IL.Add(todo_new);
            Todo_IL.Remove(todo_new);


            // Insert at index - IList

            Todo_IL.Insert(3, todo_new);
            Todo_IL.RemoveAt(3);


            return View();

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